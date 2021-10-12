from django.db import models
from django.db.models.deletion import CASCADE
from django.contrib.auth import get_user_model
from django.db.models.fields import CharField, EmailField
from django.db.models.fields.related import ForeignKey, ManyToManyField, OneToOneField

User = get_user_model()

class UserProfile(models.Model):

    user = ForeignKey(User, on_delete=CASCADE)
    favorite_offers = ManyToManyField('Offer', blank=True)
    first_name = CharField(max_length=255, blank=True, default='')
    last_name = CharField(max_length=255, blank=True, default='')
    address = CharField(max_length=255, blank=True, default='')
    phone = CharField(max_length=12, blank=True, default='')

    def __str__(self):
        if self.last_name != ' ':
            return ' '.join([self.user.first_name, self.user.last_name])
        return self.user.user_name
