from django.db import models
from django.db.models.fields import CharField
from django.db.models.fields.related import ForeignKey

class Model(models.Model):
    
    model = CharField(max_length=255)
    mark = ForeignKey('Mark', on_delete=models.CASCADE)

    def __str__(self):
        return self.model