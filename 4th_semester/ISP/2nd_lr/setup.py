#!/usr/bin/env python
from setuptools import find_packages
from setuptools import setup

setup(
    name='Serializer',
    version='1.0.0',
    description='LR2',
    packages=['src', 'src/Factory', 'src/JsonSerializer', 'src/TomlSerializer', 'src/YamlSerializer', 'src/PickleSerializer', 'src/packer'],
    author='no author',
    install_requires=['PyYaml == 5.3.1'],
    entry_points={
        'console_scripts': [
            'redump = src.redump:main'
        ]}
    )