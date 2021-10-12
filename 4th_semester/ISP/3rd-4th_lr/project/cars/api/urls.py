from rest_framework import routers

from django.urls import path, include

from . import views

router = routers.DefaultRouter()
router.register(r'users', views.UserViewSet)
router.register(r'marks', views.MarkViewSet)
router.register(r'models', views.ModelViewSet)
router.register(r'userprofiles', views.UserProfileViewSet)
router.register(r'offers', views.OfferViewSet)
router.register(r'statistics', views.StatisticsViewSet)

urlpatterns = [
    path('api-auth/', include('rest_framework.urls', namespace='rest_framework')),
]

urlpatterns += router.urls