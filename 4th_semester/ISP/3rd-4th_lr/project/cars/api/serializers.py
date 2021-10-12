from django.db.models import fields
from rest_framework import serializers

from django.contrib.auth.models import User

from ..models import *

class UserSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = User
        fields = ['url', 'id', 'username', 'email']

class MarkSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Mark
        fields = ['url', 'id', 'mark']

class ModelSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Model
        fields = ['url', 'id', 'mark', 'model']

class StatisticsSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Statistics
        fields = ['url', 'id', 'publish_date', 'total_views', 'todays_views']

class OfferSerializer(serializers.HyperlinkedModelSerializer):

    statistics = serializers.HyperlinkedIdentityField(view_name='statistics-detail')

    class Meta:
        model = Offer
        fields = [
            'url', 
            'mark', 
            'model',
            'year',
            'description',
            'price',
            'image',
            'statistics',
            'owner'
        ]

class UserProfileSerializer(serializers.HyperlinkedModelSerializer):

    # user = serializers.HyperlinkedIdentityField(view_name='user-detail')

    class Meta:
        model = UserProfile
        fields = [
            'url',
            'id', 
            'user', 
            'favorite_offers',
            'first_name',
            'last_name',
            'address',
            'phone'
        ]