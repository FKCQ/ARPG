# ARPG

实现了背包系统，战斗系统，换装系统与拾取物体功能 

技术难点：

1、攻击动作切换使用字典类存储

2、击中敌人的同时血量减退，实现动作与血量UI的同步，在角色模型动作中添加事件

3、通过修改人物模型身上的BlendShapes,解决了角色穿上盔甲，角色身体皮肤显示在盔甲表面的问题

4、通过添加和修改动作层，实现角色装备武器和盾牌时，手部握盾与握剑的动作

5、一个武器对应多个动作，定义一个结构体，动作使用数组存放
