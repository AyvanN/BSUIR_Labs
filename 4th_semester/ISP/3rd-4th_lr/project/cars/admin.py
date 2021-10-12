from PIL import Image as Img

from django.contrib import admin
from django.core.exceptions import ValidationError
from django.forms import ModelForm
from django.forms.models import fields_for_model

from .models import *


# class ImageAdminForm(ModelForm):

#     def __init__(self, *args, **kwargs):
#         super().__init__(*args, **kwargs)
#         self.fields['image'].help_text = 'Uploaded images with resolution greater than {}x{} will be resized'.format(*Image.MIN_RESOLUTION)

# class OfferAdminForm(ModelForm):
    
#     def __init__(self, *args, **kwargs):
#         super(OfferAdminForm, self).__init__(*args, **kwargs)
#         initial = self.initial
#         mark = self.initial['mark']
#         choices = Model.objects.filter(mark_id=mark)
#         self.fields['model'].widget.attrs.update({
#             'choices' : choices
#         })
        

admin.site.register(Offer)
admin.site.register(UserProfile)
admin.site.register(Statistics)
admin.site.register(Model)
admin.site.register(Mark)