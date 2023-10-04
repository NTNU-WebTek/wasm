const std = @import("std");

pub fn main() !void {
    const stdout = std.io.getStdOut().writer();
    try stdout.print("content-type: text/plain\n\n", .{});
    try stdout.print("Hello, world!\n", .{});
}

extern fn print(a: i32) void;

export fn add(a: i32, b: i32) i32 {
    print(a + b);
    return a + b;
}
