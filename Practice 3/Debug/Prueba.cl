__kernel void vadd(__global int *array,
	const int loop,
	const int inc)
{
	int i = get_global_id(0); // each kernel has a different id!!!
	i = i * 2 - i % inc;
	int j = i + inc;
	bool dir = true;
	//With this, we determine if the box is green or blue (direction of the comparison)
	if ((i & loop) != 0) {
		dir = false;
	}
	//There is no comparison between groups (between elements of diferent red boxes)
		if (array[i] > array[j] && dir) {
			int aux = array[i];
			array[i] = array[j];
			array[j] = aux;
		}
		else if (array[i] < array[j] && !dir) {
			int aux = array[i];
			array[i] = array[j];
			array[j] = aux;
	}
}