
#include <emscripten.h>

EMSCRIPTEN_KEEPALIVE
int add(int num1, int num2)
{

    return num1 + num2;
}

EMSCRIPTEN_KEEPALIVE
char *hello()
{
    return "Hello from C!";
}