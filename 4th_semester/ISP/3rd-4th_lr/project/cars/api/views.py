from rest_framework import viewsets
from rest_framework.permissions import IsAdminUser, IsAuthenticated

from .serializers import *
from ..models import *

class UserViewSet(viewsets.ModelViewSet):

    permission_classes = [IsAdminUser]

    queryset = User.objects.all()
    serializer_class = UserSerializer

class MarkViewSet(viewsets.ModelViewSet):

    permission_classes = [IsAuthenticated]

    queryset = Mark.objects.all()
    serializer_class = MarkSerializer

class ModelViewSet(viewsets.ModelViewSet):

    permission_classes = [IsAuthenticated]

    queryset = Model.objects.all()
    serializer_class = ModelSerializer

class UserProfileViewSet(viewsets.ModelViewSet):

    permission_classes = [IsAdminUser]

    queryset = UserProfile.objects.all()
    serializer_class = UserProfileSerializer

class OfferViewSet(viewsets.ModelViewSet):

    permission_classes = [IsAuthenticated]

    queryset = Offer.objects.all()
    serializer_class = OfferSerializer

class StatisticsViewSet(viewsets.ModelViewSet):

    permission_classes = [IsAuthenticated]

    queryset = Statistics.objects.all()
    serializer_class = StatisticsSerializer