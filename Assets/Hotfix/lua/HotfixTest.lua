-- 热更修复 HotfixTest类对象
local tick = 0
xlua.hotfix(CS.HotfixTest, 'Update', function()  
    tick = tick + 1
    if (tick % 50) == 0 then
        print('<<<<<<<<Update in lua, tick = ' .. tick)
    end
end)