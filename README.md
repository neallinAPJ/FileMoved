# FileMoved
﻿程序功能：移动文件
在App.config中的File节点可配置移动文件所需要的信息。
可配置项如下：
File：用来配置文件移动所需要的信息，有且只有一个。

Folder：
	该节点主要用来配置移动文件的读取路径和移动路径，可配置多个Floder节点，必须被包含在File节点里面，可配置如下属性
	1.index：该元素必需存在且唯一（相同的Floder节点,不能有重复的index的值），为该节点的索引属性，值：可输入任意数字；
	2.fromFolder：该元素必需存在，值：文件的原始路径，可以用“；”分隔输入多个路径；
	3.toFolder：该元素必需存在，值：文件的移动路径，只能输入一个路径；
	4.sub:值：默认情况下为true,可以不输入任何值，标志着是否需要遍历子文件夹，ture为需要，false未不需要；
	4.struct:值：默认情况下为true,可以不输入任何值，标志着移动后是否需要保留原来的目录结构，ture为需要，false未不需要；

search：
	该节点主要用来配置读取文件的搜索条件，可配置多个search节点，必须被包含在Folder节点里面，可配置如下属性
	1.index：该元素必需存在且唯一（相同的Floder节里面的search节点,不能有重复的index的值），为该节点的索引属性，值：可输入任意数字；
	2.key:该元素必需存在，值：配置需要搜索的条件，可以配置的条件如下
			a.CreateDate:和文件的创建日期作比较，如CreateDate=“2015-4-9",与该日期做比较；
			b.CreateDate_Day:和文件的创建日期作比较，如CreateDate_Day=“4”，与4天前的日期做比较；
			c.CreateDate_Month：和文件的创建日期作比较，如CreateDate_Month=“1”，与1个月前的日期做比较；
			d.CreateDate_Year：和文件的创建日期作比较，如CreateDate_Year=“1”，与1年前的日期做比较；
			e.LastWriteTime:和文件的最后写入日期作比较，如LastWriteTime=“2015-4-9",与该日期做比较；
			f.LastWriteTime_Day:和文件的最后写入日期作比较，如LastWriteTime_Day=“4”，与4天前的日期做比较；
			g.LastWriteTime_Month：和文件的最后写入日期作比较，如LastWriteTime_Month=“1”，与1个月前的日期做比较；
			h.LastWriteTime_Year：和文件的最后写入日期作比较，如LastWriteTime_Year=“1”，与1年前的日期做比较；
			i.LastAccessTime：和文件的最后访问日期作比较，如LastAccessTime=“2015-4-9",与该日期做比较；
			j.LastAccessTime_Day:和文件的最后访问日期作比较，如LastWriteTime_Day=“4”，与4天前的日期做比较；
			k.LastAccessTime_Month：和文件的最后访问日期作比较，如LastWriteTime_Month=“1”，与1个月前的日期做比较；
			l.LastAccessTime_Year：和文件的最后访问日期作比较，如LastWriteTime_Year=“1”，与1年前的日期做比较；
			m.FileSize:和文件的大小作比较，如FileSize=“100”，单位为KB，与100KB做比较；
			n.FileType：和文件的类型作比较，可以用“；”分隔输入多个文件类型，如FileType=“.txt;.pptx;.xlsx”,判断文件是否属于该文件类型；
			o.FileName：和文件名称作比较，如FileName=“file1”，联合操作符合搜索；
	operator:该元素必需存在，值：配置需要搜索的运算符号，可以配置的运算符号如下
			a.EQ:等于
			b.CT:包含
			c.GT:大于
			d.GE:大于等于
			e.LT:小于
			f.LE:小于等于
			g.BW:以某个字符串开始
			h.EW:以某个字符串结束

范例：
<File>
	//遍历文件夹D:\neal1;D:\neal2及其子文件夹的文件按search节点中的搜索条件，搜索到的文件移动到D:\neal4文件中，并保留原来的目录结构
    <Folder index="1" fromFolder="D:\neal1;D:\neal2" toFolder="D:\neal4" sub="true" struct="true">
		//文件的创建日期小于7天前的文件
      <search index="1" key="CreateDate_Day" value="7" operator="LT" />
	  //文件的创建日期大于等于10天前的文件
	  <search index="2" key="CreateDate_Day" value="10" operator="GE" />
	  //文件的名称以filestart开头的文件
      <search index="3" key="FileName" value="filestart" operator="BW"/>
	  //文件的名称以fileend结尾的文件
	  <search index="4" key="FileName" value="fileend" operator="EW"/>
	  //文件类型是.txt或者是.pptx的文件
	  <search index="5" key="FileType" value=".txt;.pptx" operator="CT"/>     
   </Folder>
   	//遍历文件夹D:\neal3及其子文件夹的文件按search节点中的搜索条件，搜索到的文件移动到D:\neal4文件中
    <Folder index="2" fromFolder="D:\neal3" toFolder="D:\neal4" sub="true" struct="false">
		//文件的大小，大于等于100KB的文件
      <search index="1" key="FileSize" value="100" operator="GE"/>
    </Folder>
  </File>
