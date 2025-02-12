# UnityProject

1. 战斗与玩家控制系统
精准打击检测：PlayerAttack 结合 Raycast 或 Trigger 碰撞检测 计算攻击范围，确保近战和远程攻击精准命中。
Combo 机制：支持 连击检测，玩家可以连续点击攻击键触发不同的攻击动画，提高打击感。
动画驱动攻击：使用 Animator State Machine 控制攻击动作，确保攻击、受击、闪避等状态的平滑衔接，优化战斗体验。
2. 敌人 AI 及生成优化
FSM 状态机 AI (Enemy.cs)：敌人具有 巡逻、追踪、攻击、逃跑 多种状态，采用有限状态机（FSM） 实现状态切换，提高 AI 灵活性。
路径规划：结合 NavMeshAgent 实现寻路，支持动态障碍躲避，使敌人 AI 具备更真实的移动策略。
波次生成优化：EnemySpawner 采用对象池（Object Pooling） 复用敌人实例，减少 GC 压力，优化性能。
3. 背包与资源管理
基于 ScriptableObject 的物品系统：通过 InventoryManager 使用 ScriptableObject 设计物品属性，支持物品存储、使用、销毁，减少冗余代码，提高扩展性。
UI 响应式优化：PlayerPropertyUI 采用 事件驱动（Observer Pattern） 实时更新血量、装备栏，减少不必要的 Update() 计算，提升性能。
4. 视觉优化与性能调优
摄像机动态调整：CameraController 实现 基于 Cinemachine 的平滑跟随，增强玩家沉浸感。
GPU 加速：优化 粒子特效（VFX Graph），减少 Draw Calls，提升渲染效率。
异步加载场景：使用 Addressables 资源管理系统，实现场景异步加载，减少卡顿，提高流畅度。
