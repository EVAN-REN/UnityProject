# UnityProject
![](https://github.com/EVAN-REN/UnityProject/blob/main/Image/U1.gif)
![](https://github.com/EVAN-REN/UnityProject/blob/main/Image/U2.gif)
1. 战斗与玩家控制系统
精准打击检测：PlayerAttack 结合 Raycast 或 Trigger 碰撞检测 计算攻击范围，确保近战和远程攻击精准命中。
Combo 机制：支持 连击检测，玩家可以连续点击攻击键触发不同的攻击动画，提高打击感。
动画驱动攻击：使用 Animator State Machine 控制攻击动作，确保攻击、受击、闪避等状态的平滑衔接，优化战斗体验。

![](https://github.com/EVAN-REN/UnityProject/blob/main/Image/U12.png)
2. 武器系统：近战与远程武器机制
多武器支持：设计 近战（刀、斧、镰刀）和远程武器（弓箭、枪械），支持不同的攻击方式、动画和伤害计算。
武器切换：通过 装备系统 允许玩家动态切换武器，使用 Animator Override Controller 替换不同武器的攻击动画，确保流畅过渡。
近战武器机制：
精准打击检测：使用 Raycast 或 Trigger 碰撞检测 计算攻击范围，确保攻击精准命中。
远程武器机制：
抛物线投射：弓箭、投掷物使用 Rigidbody + 物理模拟 计算抛物线轨迹，确保弹道符合现实物理。
子弹管理优化：使用 对象池（Object Pooling） 复用子弹对象，减少实例化开销，提高性能。

3. 敌人 AI 及生成优化
FSM 状态机 AI (Enemy.cs)：敌人具有 巡逻、追踪、攻击、逃跑 多种状态，采用有限状态机（FSM） 实现状态切换，提高 AI 灵活性。
路径规划：结合 NavMeshAgent 实现寻路，支持动态障碍躲避，使敌人 AI 具备更真实的移动策略。
波次生成优化：EnemySpawner 采用对象池（Object Pooling） 复用敌人实例，减少 GC 压力，优化性能。

![](https://github.com/EVAN-REN/UnityProject/blob/main/Image/U11.png)
4. 背包与资源管理
基于 ScriptableObject 的物品系统：通过 InventoryManager 使用 ScriptableObject 设计物品属性，支持物品存储、使用、销毁，减少冗余代码，提高扩展性。
UI 响应式优化：PlayerPropertyUI 采用 事件驱动（Observer Pattern） 实时更新血量、装备栏，减少不必要的 Update() 计算，提升性能。

5. 视觉优化与性能调优
摄像机动态调整：CameraController 实现 基于 Cinemachine 的平滑跟随，增强玩家沉浸感。
GPU 加速：优化 粒子特效（VFX Graph），减少 Draw Calls，提升渲染效率。
异步加载场景：使用 Addressables 资源管理系统，实现场景异步加载，减少卡顿，提高流畅度。

![](https://github.com/EVAN-REN/UnityProject/blob/main/Image/U21.png)
6. UI 动画与交互优化
UI 动画流畅度优化：采用 DOTween 控制 UI 过渡动画（如按钮缩放、界面切换），减少复杂的 Animator 逻辑，提高动画表现力和响应速度。
动态 UI 适配：使用 Auto Layout 和 Canvas Scaler 实现自适应布局，确保 UI 在不同分辨率下均能正确显示，提升可用性。
Avatar Mask 动画蒙板：利用 Avatar Mask 分离 上下半身动画，支持玩家在移动时独立执行攻击、换武器等操作，提高战斗流畅度与自由度。
事件驱动 UI 更新：结合 Observer Pattern（观察者模式），在武器切换、血量变化等事件触发时，UI 自动更新，避免 Update() 轮询，提高性能。
交互动画增强：按钮点击、背包物品拖拽等操作均配备渐变、高亮、缩放等动画反馈，提升用户体验。

