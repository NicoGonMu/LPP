__kernel void bitonic(__global int* array, const int m, const int j)
{
	int id = get_global_id(0);  //Kernel index	

	//Renaming for clarity purposes
	int x = id * 2 - (id % j);	
	int y = x + j;

	bool dir = x & m;

	//Swap
	if ((dir && array[y] > array[x]) || (!dir && array[x] > array[y])) {
		int aux = array[x];
		array[x] = array[y];
		array[y] = aux;
	}
}