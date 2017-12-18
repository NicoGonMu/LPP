
#include <CL/cl.h>
#include <iostream>
#include <vector>

using namespace std;

#pragma comment(lib, "OpenCL.lib")

char* getDescriptionOfError(cl_int error) {
	switch (error) {
	case CL_SUCCESS:                            return "Success!";
	case CL_DEVICE_NOT_FOUND:                   return "Device not found.";
	case CL_DEVICE_NOT_AVAILABLE:               return "Device not available";
	case CL_COMPILER_NOT_AVAILABLE:             return "Compiler not available";
	case CL_MEM_OBJECT_ALLOCATION_FAILURE:      return "Memory object allocation failure";
	case CL_OUT_OF_RESOURCES:                   return "Out of resources";
	case CL_OUT_OF_HOST_MEMORY:                 return "Out of host memory";
	case CL_PROFILING_INFO_NOT_AVAILABLE:       return "Profiling information not available";
	case CL_MEM_COPY_OVERLAP:                   return "Memory copy overlap";
	case CL_IMAGE_FORMAT_MISMATCH:              return "Image format mismatch";
	case CL_IMAGE_FORMAT_NOT_SUPPORTED:         return "Image format not supported";
	case CL_BUILD_PROGRAM_FAILURE:              return "Program build failure";
	case CL_MAP_FAILURE:                        return "Map failure";
	case CL_INVALID_VALUE:                      return "Invalid value";
	case CL_INVALID_DEVICE_TYPE:                return "Invalid device type";
	case CL_INVALID_PLATFORM:                   return "Invalid platform";
	case CL_INVALID_DEVICE:                     return "Invalid device";
	case CL_INVALID_CONTEXT:                    return "Invalid context";
	case CL_INVALID_QUEUE_PROPERTIES:           return "Invalid queue properties";
	case CL_INVALID_COMMAND_QUEUE:              return "Invalid command queue";
	case CL_INVALID_HOST_PTR:                   return "Invalid host pointer";
	case CL_INVALID_MEM_OBJECT:                 return "Invalid memory object";
	case CL_INVALID_IMAGE_FORMAT_DESCRIPTOR:    return "Invalid image format descriptor";
	case CL_INVALID_IMAGE_SIZE:                 return "Invalid image size";
	case CL_INVALID_SAMPLER:                    return "Invalid sampler";
	case CL_INVALID_BINARY:                     return "Invalid binary";
	case CL_INVALID_BUILD_OPTIONS:              return "Invalid build options";
	case CL_INVALID_PROGRAM:                    return "Invalid program";
	case CL_INVALID_PROGRAM_EXECUTABLE:         return "Invalid program executable";
	case CL_INVALID_KERNEL_NAME:                return "Invalid kernel name";
	case CL_INVALID_KERNEL_DEFINITION:          return "Invalid kernel definition";
	case CL_INVALID_KERNEL:                     return "Invalid kernel";
	case CL_INVALID_ARG_INDEX:                  return "Invalid argument index";
	case CL_INVALID_ARG_VALUE:                  return "Invalid argument value";
	case CL_INVALID_ARG_SIZE:                   return "Invalid argument size";
	case CL_INVALID_KERNEL_ARGS:                return "Invalid kernel arguments";
	case CL_INVALID_WORK_DIMENSION:             return "Invalid work dimension";
	case CL_INVALID_WORK_GROUP_SIZE:            return "Invalid work group size";
	case CL_INVALID_WORK_ITEM_SIZE:             return "Invalid work item size";
	case CL_INVALID_GLOBAL_OFFSET:              return "Invalid global offset";
	case CL_INVALID_EVENT_WAIT_LIST:            return "Invalid event wait list";
	case CL_INVALID_EVENT:                      return "Invalid event";
	case CL_INVALID_OPERATION:                  return "Invalid operation";
	case CL_INVALID_GL_OBJECT:                  return "Invalid OpenGL object";
	case CL_INVALID_BUFFER_SIZE:                return "Invalid buffer size";
	case CL_INVALID_MIP_LEVEL:                  return "Invalid mip-map level";
	default: return "Unknown";
	}
}

int* generateArray(int dID) {
	int* ret = new int[dID];
	for (int i = 0; i < dID; i++) {
		ret[i] = rand();
	}
	return ret;
}

char* readSource() {
	FILE *f = fopen("./src.cl", "r");
	fseek(f, 0, SEEK_END);
	int size = ftell(f);
	fseek(f, 0, SEEK_SET);
	char *src = new char[size + 1];
	int readChars = fread(src, 1, size, f);
	src[readChars] = '\0';
	fclose(f);

	return src;
}

void printArray(int* elements, int len) {
	int j = len;
	for (int i = 0; i < j; i++)
	{
		cout << elements[i] << " ";
	}
}

double getTime(cl_command_queue queue, cl_event event) {
	cl_ulong ret = 0;
	clWaitForEvents(1, &event);
	clFinish(queue);

	cl_ulong timeStartSend;
	clGetEventProfilingInfo(event, CL_PROFILING_COMMAND_START, sizeof(cl_ulong), &timeStartSend, NULL);
	clGetEventProfilingInfo(event, CL_PROFILING_COMMAND_END, sizeof(cl_ulong), &ret, NULL);

	ret -= timeStartSend;
	return ret;
}


int main(int argc, char** argv)
{
	int sizeBuffer = 10240;
	char* buffer = new char[sizeBuffer];
	cl_uint buf_uint;
	cl_ulong buf_ulong;
	cl_int error = 0;   // Utilizado para la gestion de errores
	cl_uint numPlatforms;
	cl_platform_id* platforms;
	cl_uint numDevices;
	cl_device_id* devices;


	// Platform
	error = clGetPlatformIDs(0, NULL, &numPlatforms);
	if (error != CL_SUCCESS) {
		cout << "Error getting platform id: " << getDescriptionOfError(error) << endl;
		exit(error);
	}

	cout << numPlatforms << " platforms" << endl;

	platforms = new cl_platform_id[numPlatforms];
	error = clGetPlatformIDs(numPlatforms, platforms, NULL);
	if (error != CL_SUCCESS) {
		cout << "Error getting platform id: " << getDescriptionOfError(error) << endl;
		exit(error);
	}

	std::vector<cl_device_id> deviceIDs = {};
	for (int p = 0; p < numPlatforms; ++p) {
		// Number of devices
		cl_platform_id platform = platforms[p];
		error = clGetDeviceIDs(platform, CL_DEVICE_TYPE_ALL, 0, NULL, &numDevices);
		if (error != CL_SUCCESS) {
			cout << "Error getting device ids: " << getDescriptionOfError(error) << endl;
			continue;
		}

		cout << "  =========================" << endl;
		clGetPlatformInfo(platform, CL_PLATFORM_PROFILE, sizeBuffer, buffer, NULL);
		cout << "  PROFILE = " << buffer << endl;
		cout << "  ID = " << p << endl;
		clGetPlatformInfo(platform, CL_PLATFORM_VERSION, sizeBuffer, buffer, NULL);
		cout << "  VERSION = " << buffer << endl;
		clGetPlatformInfo(platform, CL_PLATFORM_NAME, sizeBuffer, buffer, NULL);
		cout << "  NAME = " << buffer << endl;
		clGetPlatformInfo(platform, CL_PLATFORM_VENDOR, sizeBuffer, buffer, NULL);
		cout << "  VENDOR = " << buffer << endl;
		clGetPlatformInfo(platform, CL_PLATFORM_EXTENSIONS, sizeBuffer, buffer, NULL);

		// Devices
		devices = new cl_device_id[numDevices];
		error = clGetDeviceIDs(platform, CL_DEVICE_TYPE_ALL, numDevices, devices, NULL);
		if (error != CL_SUCCESS) {
			cout << "Error getting devices: " << getDescriptionOfError(error) << endl;
		}

		for (int d = 0; d < numDevices; ++d) {
			cl_device_id device = devices[d];
			deviceIDs.push_back(device);
			cout << "  -------------------------" << endl;
			clGetDeviceInfo(device, CL_DEVICE_NAME, sizeBuffer, buffer, NULL);
			cout << "    DEVICE_NAME = " << buffer << endl;
			cout << "    DEVICE_ID = " << deviceIDs.size() << endl;
			cl_device_type deviceType;
			clGetDeviceInfo(device, CL_DEVICE_TYPE, sizeof(deviceType), &deviceType, NULL);
			if (deviceType == CL_DEVICE_TYPE_GPU)
				cout << "    CL_DEVICE_TYPE = " << "GPU" << endl;
			if (deviceType == CL_DEVICE_TYPE_CPU)
				cout << "    CL_DEVICE_TYPE = " << "CPU" << endl;
			clGetDeviceInfo(device, CL_DEVICE_VENDOR, sizeBuffer, buffer, NULL);
			cout << "    DEVICE_VENDOR = " << buffer << endl;
			clGetDeviceInfo(device, CL_DEVICE_VERSION, sizeBuffer, buffer, NULL);
			cout << "    DEVICE_VERSION = " << buffer << endl;
			clGetDeviceInfo(device, CL_DRIVER_VERSION, sizeBuffer, buffer, NULL);
			cout << "    DRIVER_VERSION = " << buffer << endl;
			clGetDeviceInfo(device, CL_DEVICE_MAX_COMPUTE_UNITS, sizeof(buf_uint), &buf_uint, NULL);
			cout << "    DEVICE_MAX_COMPUTE_UNITS = " << (unsigned int)buf_uint << endl;
			clGetDeviceInfo(device, CL_DEVICE_MAX_CLOCK_FREQUENCY, sizeof(buf_uint), &buf_uint, NULL);
			cout << "    DEVICE_MAX_CLOCK_FREQUENCY = " << (unsigned int)buf_uint << endl;
			clGetDeviceInfo(device, CL_DEVICE_GLOBAL_MEM_SIZE, sizeof(buf_ulong), &buf_ulong, NULL);
			cout << "    DEVICE_GLOBAL_MEM_SIZE = " << (unsigned long long)buf_ulong << endl;
			clGetDeviceInfo(device, CL_DEVICE_MAX_WORK_GROUP_SIZE, sizeof(buf_uint), &buf_uint, NULL);
			cout << "    DEVICE_MAX_WORK_GROUP_SIZE = " << (unsigned int)buf_uint << endl;
			clGetDeviceInfo(device, CL_DEVICE_MAX_CONSTANT_ARGS, sizeof(buf_uint), &buf_uint, NULL);
			cout << "    CL_DEVICE_MAX_CONSTANT_ARGS = " << (unsigned int)buf_uint << endl;
			clGetDeviceInfo(device, CL_DEVICE_MAX_CONSTANT_BUFFER_SIZE, sizeof(buf_ulong), &buf_ulong, NULL);
			cout << "    CL_DEVICE_MAX_CONSTANT_BUFFER_SIZE = " << (unsigned long long)buf_ulong << endl;

		}
	}

	int pID, dID;
	cl_platform_id selected_platform;
	cl_device_id selected_device;
	bool valid = false;
	while (!valid) {
		// Platform selection
		cout << endl << endl << "Please, insert the platform ID that you want to use: ";
		cin >> pID;
		selected_platform = platforms[pID];

		// Get platform devices
		error = clGetDeviceIDs(selected_platform, CL_DEVICE_TYPE_ALL, 0, NULL, &numDevices);
		devices = new cl_device_id[numDevices];
		error = clGetDeviceIDs(selected_platform, CL_DEVICE_TYPE_ALL, numDevices, devices, NULL);

		// Device selection
		cout << "Now, introduce the device ID that you want to use: ";
		cin >> dID;
		if (dID >= numDevices) {
			cout << "Invalid device and/or platform. Please, select valid ones.";
			continue;
		}
		valid = true;
		selected_device = deviceIDs.at(dID);
	}

	// Array length selection
	valid = false;
	while (!valid) {
		cout << "How many elements must be sorted? (Only powers of two supported)" << endl;
		cin >> dID;
		if ((dID != 0) && ((dID & (dID - 1)) == 0)) {
			valid = true;
		}
		else {
			cout << "Introduced number is not a power of two." << endl;
		}
	}
	//Create array to sort
	int* elements = generateArray(dID);
	int* sortedElements = new int[dID];
	cout << "\n\nElements to sort: ";
	printArray(elements, dID);

	//Create context	
	cl_context_properties properties[] = { CL_CONTEXT_PLATFORM, (cl_context_properties)selected_platform, 0 };
	cl_context clctx = clCreateContext(properties, 1, &selected_device, 0, 0, &error);

	//Create device queue
	cl_command_queue queue = clCreateCommandQueue(clctx, selected_device, CL_QUEUE_PROFILING_ENABLE, &error);

	//Read source file
	const char *src = readSource();

	//Create source
	cl_program clprogr = clCreateProgramWithSource(clctx, 1, &src, 0, &error);

	//Compile source	
	error = clBuildProgram(clprogr, 1, &selected_device, NULL, 0, 0);

	//Create Kernel
	cl_kernel clkern = clCreateKernel(clprogr, "bitonic", &error);

	//Input buffer	
	int memSize = dID * sizeof(int);
	cl_mem dev = clCreateBuffer(clctx, CL_MEM_READ_WRITE, memSize, NULL, NULL);
	cl_event evt = NULL;
	clEnqueueWriteBuffer(queue, dev, CL_TRUE, 0, memSize, elements, 0, NULL, &evt);
	cl_ulong writeTime = getTime(queue, evt);

	//Add parameters
	clSetKernelArg(clkern, 0, sizeof(cl_mem), (void *)&dev);

	//Loop
	int blocks = log2(dID);
	int m = 1;
	cl_ulong loopTime = 0;
	for (int i = 1; i <= blocks; i++) {                                                       //i = big blocks
		m = m * 2;
		clSetKernelArg(clkern, 1, sizeof(cl_mem), (void*)&m);
		for (int j = 1; j <= i; j++) {                                                        // j = red block columns
			int compElement = pow(2, (i - j));				                                  //Distance between elements to compare
			clSetKernelArg(clkern, 2, sizeof(cl_mem), (void*)&compElement);
			size_t comparisons[1] = { (dID / 2) };                                            // Number of comparisons to be done
			clEnqueueNDRangeKernel(queue, clkern, 1, NULL, comparisons, NULL, 0, NULL, &evt);
			loopTime += getTime(queue, evt);
		}
	}	
	clEnqueueReadBuffer(queue, dev, CL_TRUE, 0, memSize, sortedElements, 0, NULL, &evt);
	cl_ulong readTime = getTime(queue, evt);

	cout << "\nSorted elements: ";
	printArray(sortedElements, dID);

	//Release memory
	clReleaseMemObject(dev);
	
	cout << "\nTotal elapsed time: " << writeTime + loopTime + readTime;
	cout << "\nWrite elapsed time: " << writeTime;
	cout << "\nLoop elapsed time: " << loopTime;
	cout << "\nRead elapsed time: " << readTime;

	cout << "\nEnter something to finish.";
	int a = 0;
	cin >> a;
}