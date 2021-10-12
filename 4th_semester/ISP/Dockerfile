FROM python:3.8

ENV TARGETPATH=/home/BSUIR/First_LR/app/

RUN mkdir -p "${TARGETPATH}"

WORKDIR "${TARGETPATH}"

COPY . "${TARGETPATH}"

CMD ["python3","main.py"]