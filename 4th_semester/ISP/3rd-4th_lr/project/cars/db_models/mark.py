from django.db import models
from django.db.models.fields import CharField

class Mark(models.Model):
    
    mark = CharField(max_length=255)

    def __str__(self):
        return self.mark