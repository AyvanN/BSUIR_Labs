import logging

logging.basicConfig(level=logging.INFO)


def fibonacci(n):
    if n == 0:
        return 0
    elif n == 1 or n == 2:
        return 1
    else:
        return fibonacci(n-1) + fibonacci(n-2)


def main():
    logging.info(fibonacci(14))


if __name__ == "__main__":
    main()