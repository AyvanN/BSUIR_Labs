import pytest

from django.test import RequestFactory
from django.contrib.auth import get_user_model
from django.contrib.auth.models import User
from .models import *
from .views import *
from PIL import Image
from django.core.files.base import File
from io import BytesIO
from django.contrib.messages.storage.fallback import FallbackStorage
from django.test import Client


# User = get_user_model()

@pytest.fixture
def get_image_file1():
    name='silvia.jpg' 
    ext='jpeg'
    size=(700, 700)
    color=(256, 0, 0)
    file_obj = BytesIO()
    image = Image.new("RGB", size=size, color=color)
    image.save(file_obj, ext)
    file_obj.seek(0)
    return File(file_obj, name=name)

@pytest.fixture
def user(db):
    user = User.objects.create_user(username='testuser', email='', password='password')
    return user


@pytest.fixture
def userprofile(db, user):
    userprofile = UserProfile.objects.create(user=user, phone="1111", address="TestAddress")
    return userprofile


@pytest.fixture
def mark(db):
    mark = Mark.objects.create(mark='Toyota')
    return mark

@pytest.fixture
def model(db, mark):
    model = Model.objects.create(model='Supra', mark=mark)
    return model

@pytest.fixture
def date(db):
    date = datetime.now()
    return date

@pytest.fixture
def statistics(db, date):
    stats = Statistics.objects.create(publish_date=date)
    return stats

@pytest.fixture
def offer(db, userprofile, statistics, mark, model, get_image_file1):
    image = get_image_file1
    offer = Offer.objects.create(
            mark = mark,
            model = model,
            year = 1989,
            image = image,
            price = 23000,
            description = 'Rocket!',
            owner = userprofile,
            statistics = statistics
    )
    return offer



@pytest.mark.parametrize("expected", [1])
def test_add_to_favorites(userprofile, offer, expected):
        userprofile.favorite_offers.add(offer)
        assert userprofile.favorite_offers.count() == expected


@pytest.mark.parametrize("expected", [302])
def test_response_from_add_to_favorites_view(user, offer, expected):
    factory = RequestFactory()
    request = factory.get('')
    setattr(request, 'session', 'session')
    messages = FallbackStorage(request)
    setattr(request, '_messages', messages)
    request.user = user
    response = AddFavoriteView.as_view()(request, offer.pk)
    assert response.status_code == expected


def test_response_from_index_view(user):
        factory = RequestFactory()
        request = factory.get('')
        request.user = user
        response = IndexView.as_view()(request)
        assert response.status_code == 200


def test_response_from_offer_details(user, mark, model, offer):
        factory = RequestFactory()
        request = factory.get('')
        request.user = user
        response = OfferDetails.as_view()(request, mark, model, offer.pk)
        assert response.status_code == 200

@pytest.mark.django_db
def test_signin_get_view(user):
        factory = RequestFactory()
        request = factory.get('')
        request.user = user
        response = SignInView.as_view()(request)
        assert response.status_code == 200

@pytest.mark.django_db
def test_signin_post_view(db, user):
    c = Client()
    response = c.post('/signin/', {'username': 'testuser', 'password': 'password'})
    assert response.status_code == 302

@pytest.mark.parametrize("expected", [302])
def test_signup_post_view(db, expected):
    c = Client()
    response = c.post('/signup/', {
        'username': 'vlados', 'password': 'admin', 'confirm_password': 'admin', 'phone': '12356', 
        'first_name': 'Vlad', 'last_name': 'Borat', 'address': 'Bedy, 4', 'email': 'example@boom.com'
    })
    assert response.status_code == expected

@pytest.mark.django_db
def test_favorites_get_view(user, userprofile):
        factory = RequestFactory()
        request = factory.get('')
        request.user = user
        print(UserProfile.objects.all())
        response = FavoriteOffersView.as_view()(request)
        assert response.status_code == 200

@pytest.mark.django_db
def test_selfoffers_get_view(user, userprofile):
    factory = RequestFactory()
    request = factory.get('')
    request.user = user
    response = SelfOffersView.as_view()(request)
    assert response.status_code == 200

@pytest.mark.django_db
def test_add_offer_get_view(user, userprofile):
    factory = RequestFactory()
    request = factory.get('')
    request.user = user
    response = AddOfferView.as_view()(request)
    assert response.status_code == 200

@pytest.mark.django_db
def test_offers_get_view(user, userprofile):
    factory = RequestFactory()
    request = factory.get('')
    request.user = user
    response = OffersView.as_view()(request)
    assert response.status_code == 200

@pytest.mark.django_db
def test_marks_get_view(user, userprofile, mark, offer):
    factory = RequestFactory()
    request = factory.get('')
    request.user = user
    response = MarksView.as_view()(request, mark)
    assert response.status_code == 200

@pytest.mark.django_db
def test_models_get_view(user, userprofile, mark, model, offer):
    factory = RequestFactory()
    request = factory.get('')
    request.user = user
    response = ModelsView.as_view()(request, mark, model)
    assert response.status_code == 200

@pytest.mark.parametrize("expected", [302, '/profile/selfoffers/'])
def test_add_offer_post_view(db, expected, get_image_file1, mark, model, statistics):
    c = Client()
    image = get_image_file1
    image.seek(0)
    response = c.post('/profile/selfoffers/addoffer', {
        'mark':  'Honda',
        'model' : 'Accord',
        'image':image,
        'description' : 'some',
        'price' : 13000, 
        'year' : 2007,
    })
    print(response.url)
    assert response.status_code, response.url == expected