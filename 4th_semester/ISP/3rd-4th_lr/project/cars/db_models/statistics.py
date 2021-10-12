from django.db import models
from django.db.models.fields import DateTimeField, IntegerField
from django.db.models.fields.related import OneToOneField

class Statistics(models.Model):

    publish_date = DateTimeField('publishing date')
    total_views = IntegerField(default=0)
    todays_views = IntegerField(default=0)

    def __str__(self):
        if('caroffer' in self.__dict__):
            return str(self.offer) + ' ' + str(self.publish_date)
        else:
            return str(self.pk) + ' ' + str(self.publish_date)
