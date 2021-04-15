using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutLiner : ScriptableRendererFeature
{
    [System.Serializable]
    public class Setting
    {
        public RenderTexture rt;
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPrepasses;
        public Material purMat;
        public Material edgeMat;
    }

    public Setting setting;
    public OutLineRenderPass outLineRenderPass;
    
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        var source = renderer.cameraColorTarget;
        var dest = RenderTargetHandle.CameraTarget;
        outLineRenderPass.SetUp(source,dest);
        renderer.EnqueuePass(outLineRenderPass);
    }

    public override void Create()
    {
        setting.rt = new RenderTexture(Camera.main.pixelWidth,Camera.main.pixelHeight,32);
        outLineRenderPass = new OutLineRenderPass(setting.rt, setting.renderPassEvent, setting.purMat, setting.edgeMat);

    }
    
}

public class OutLineRenderPass : ScriptableRenderPass
{
    public RenderTexture rt;
    public Material purMat;
    public Material edgeMat;
    private RenderTargetIdentifier source;
    private RenderTargetHandle dest;

    private CommandBuffer cmd;
    private Renderer renderer;
    public OutLineRenderPass(RenderTexture rt, RenderPassEvent rpv, Material purMat, Material edgeMat)
    {
        renderPassEvent = rpv;
        this.rt = rt;
        this.purMat = purMat;
        this.edgeMat = edgeMat;

    }
    
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        cmd = CommandBufferPool.Get("edgeCmd");
        cmd.SetRenderTarget(rt);
        cmd.DrawRenderer(renderer, purMat,0,0);
        edgeMat.SetTexture("_Mask" ,rt);
        
        cmd.Blit(source, dest.Identifier(), edgeMat, 0, 0);
        
        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
        rt.Release();
    }

    public void SetUp(RenderTargetIdentifier source, RenderTargetHandle dest)
    {
        this.source = source;
        this.dest = dest;

    }
}