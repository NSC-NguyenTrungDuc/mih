package nta.med.orca.gw.socket;

import io.netty.bootstrap.ServerBootstrap;
import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.buffer.UnpooledByteBufAllocator;
import io.netty.channel.*;
import io.netty.channel.nio.NioEventLoopGroup;
import io.netty.channel.socket.SocketChannel;
import io.netty.channel.socket.nio.NioServerSocketChannel;
import io.netty.util.internal.PlatformDependent;
import nta.med.common.glossary.Lifecyclet;

import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public class NioFileServer extends Lifecyclet {

    private final String host;
    private final int port;
    private final int bossCount;
    private final int workerCount;
    private final String folderPath;
    private final SyncHandler syncHandler;
    protected ServerBootstrap bootstrap;
    protected EventLoopGroup bossEventLoop;
    protected EventLoopGroup workerEventLoop;
    private final ExecutorService executor;

    public NioFileServer(String host, int port, int bossCount, int workerCount, String folderPath, SyncHandler syncHandler) {
        this.host = host;
        this.port = port;
        this.bossCount = bossCount;
        this.workerCount = workerCount;
        this.folderPath = folderPath;
        this.syncHandler = syncHandler;
        this.executor = Executors.newFixedThreadPool(100);
    }

    @Override
    protected void doStart() throws Exception {
        bossEventLoop = new NioEventLoopGroup(bossCount);
        workerEventLoop = new NioEventLoopGroup(workerCount);
        bootstrap = new ServerBootstrap();
        bootstrap.group(bossEventLoop, workerEventLoop)
                .channel(NioServerSocketChannel.class)
                .option(ChannelOption.SO_BACKLOG, 1024)
                .option(ChannelOption.SO_REUSEADDR, true)
                .childOption(ChannelOption.TCP_NODELAY, true)
                .childOption(ChannelOption.SO_KEEPALIVE, true)
                .childOption(ChannelOption.ALLOCATOR, new UnpooledByteBufAllocator(PlatformDependent.directBufferPreferred()))
                .childHandler(new ChannelInitializer<SocketChannel>() {
                    @Override
                    public void initChannel(SocketChannel ch) throws Exception {
                        ChannelPipeline p = ch.pipeline();
                        p.addLast("handler", new InboundHandler());
                    }
                });
        if(this.host != null)  bootstrap.bind(host, port).sync(); else bootstrap.bind(port).sync();
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        if(this.bossEventLoop != null) this.bossEventLoop.shutdownGracefully();
        if(this.workerEventLoop != null) this.workerEventLoop.shutdownGracefully();
        return timeout;
    }

    class InboundHandler extends ChannelInboundHandlerAdapter {

        private byte[] RETURN = new byte[] {0x06};

        private OutputStream fos = null;
        private byte[] buffer = new byte[4096];
        private String storedFile;

        @Override
        public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception {
//            if(msg instanceof ByteBuf) {
//                ByteBuf t = (ByteBuf)msg;
//                if(t.readableBytes() > 0){
//                    if(fos == null) {
//                        storedFile = String.format("%s/claim-%s.xml", folderPath, System.currentTimeMillis());
//                        fos = new FileOutputStream(storedFile);
//                    }
//                    
//                    boolean eof = t.getByte(t.readableBytes() - 1) == 0x04;
//                    int redundantBytes = 0;
//                    while(!eof || t.readerIndex() < t.writerIndex()){
//                    	int read = Math.min(t.readableBytes(), buffer.length);                    	                    	                    
//                    	if(t.readerIndex() + buffer.length >= t.writerIndex()) {
//                    		redundantBytes = eof ? 1 : 0;                    		
//                    	}
//                    	t.readBytes(buffer, 0, read);
//                        fos.write(buffer, 0, read - redundantBytes);                        
//                        if(t.readerIndex() == t.writerIndex()) break;
//                    }                    
//                    
//                    if(eof) {
//                    	fos.flush();
//                        fos.close();
//                        ctx.channel().writeAndFlush(Unpooled.wrappedBuffer(RETURN));
//                        ctx.channel().close();
//                        executor.submit(() -> syncHandler.handle(storedFile));
//                    }
//                }
//            } else {
//                ctx.fireChannelRead(msg);
//            }
        }
    }
}
