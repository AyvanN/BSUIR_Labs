#include <stdio.h>
#include <stdlib.h>

double input_check(double check)
{
	while(1)
	{
		if (scanf_s("%lf", &check) != 1) {
			printf("Invalid input.Try again.\n");
			scanf_s("%*[^\n]");
		}
		else break;
	}
	return check;
}

double pasting_area(double ceiling, double lenght, double width, int windows, int doors, double door, double window)
{
	double area;
	area = (ceiling * lenght) + (ceiling * width) - (door * doors) - (window * windows);
	return area;
}

double tubes(double area, double tubewidth, double tubelength)
{
	double wallpaper_tubes;
	wallpaper_tubes = area / (tubelength * tubewidth);
	return wallpaper_tubes;
}

double cost(double gluecost, double number_of_tubes, double cost_of_tube)
{
	double cost;
	cost = (gluecost * number_of_tubes)+(number_of_tubes * cost_of_tube);
	return cost;
}

void main(void)
{
	const double window = 2.15 * 1.5;
	const double door = 0.9 * 2.05;
	const double ceiling = 2.6;
	const double gluecost = 2.5/5;
	const double tubelength = 10;
	const double tubewidth = 0.5;
	int choise = 0, windows = 0, doors = 0;
	double length = 0, width = 0, area = 0, number_of_tubes = 0, cost_of_tube = 0;

	do
	{
		choise = 0;
		printf("\n1)Entering room length and width\n");
		printf("2)Enter the number of windows\n");
		printf("3)Enter the number of doorways\n");
		printf("4)Enter the cost of the wallpaper tube\n");
		printf("5)Calculation of the area of pasting\n");
		printf("6)Calculation of the required number of wallpaper tubes\n");
		printf("7)Calculation of the cost of sticking\n");
		printf("8)Exit\n");
		choise = input_check(choise);
		system("cls");
		switch (choise)
		{
		case 1:
		
			printf("length: ");
			length = input_check(length);
			printf("width: ");
			width = input_check(width);
			break;
		
		case 2:
		
			printf("Number of windows: ");
			windows = input_check(windows);
			break;
		
		case 3:
		
			printf("Number of doors: ");
			doors = input_check(doors);
			break;
		
		case 4:
		
			printf("cost of tube: ");
			cost_of_tube = input_check(cost_of_tube);
			break;
		
		case 5:
			area = pasting_area(ceiling, length, width, windows, doors, door, window);
			printf("area of pasting: %lf\n", area);
			break;
		case 6:
			number_of_tubes = tubes(area, tubewidth, tubelength);
			printf("required number of wallpaper tubes: %lf\n", number_of_tubes);
			break;
		case 7:
			printf("cost of sticking: %lf\n", cost(gluecost, number_of_tubes, cost_of_tube));
			break;
		case 8:break;
		default:
			printf("Wrong option selected\n");
			break;
		}
	} while (choise != 8);
}
