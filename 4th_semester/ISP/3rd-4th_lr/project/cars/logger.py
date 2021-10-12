import logging
import logging.config
import yaml
from django.conf import settings

with open('config.yaml', 'r') as f:
    log_cfg = yaml.safe_load(f.read())
logging.config.dictConfig(log_cfg)

if settings.DEBUG:
    formatter = logging.Formatter('Режим DEBUG: %(asctime)s  %(name)s  %(levelname)s: %(message)s')
    logging.getLogger('dev').handlers[0].setFormatter(formatter)
    logging.getLogger('dev').handlers[1].setFormatter(formatter)

logger = logging.getLogger('dev')