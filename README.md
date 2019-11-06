# NATnetty
基于netty自己搭建服务器，实现内外网的穿透，根据需要实现完全自定义。优点是可以通过配置代理端口实现本地网站或应用的代理，没有任何限制，在其他的pc上通过公网IP+指定端口访问内网计算机上的资源，缺点是需要自己搭建一个公网服务器，且传输速度与公网带宽有关系。



# 使用方法

1、下载文件并解压；

https://github.com/YouAreOnlyOne/NATnetty/raw/master/Files/NAT.zip

2、双击运行里面的 NATnetty.exe 文件即可。


# C#笔记

启用 process 类，

using System.Diagnostics;//注意引用这个空间

Process p = new Process();

p.StartInfo.FileName = "cmd.exe";

str="一些cmd命令"

p.Start();

p.StandardInput.WriteLine(str);//这里就是执行这些命令，相当于你在cmd窗口敲了一遍这些命令

p.StandardInput.WriteLine("exit");//都下执行完退出

string strRst = p.StandardOutput.ReadToEnd();

//最后console输出返回到 strRst变量。然后你再处理这个变量。
