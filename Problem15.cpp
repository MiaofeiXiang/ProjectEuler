#include<stdlib.h>
#include<iostream>
#define GRIDNUM 20

using namespace std;

int main()
{
	long long Grid[GRIDNUM+1][GRIDNUM+1]={0};
	int row;
        int column;
        row = GRIDNUM;
	for(column = 0; column<=GRIDNUM; column++)
            Grid[row][column] = 1;
        column = GRIDNUM;
        for(row = 0; row<=GRIDNUM-1; row++)
            Grid[row][column] = 1;
        for(row = GRIDNUM-1;row>=0; row--)
           for(column = GRIDNUM-1;column>=0;column--)
              Grid[row][column] = Grid[row+1][column] + Grid[row][column+1];
        cout<<Grid[0][0]<<endl;
	system("pause");
	return 0;
}
