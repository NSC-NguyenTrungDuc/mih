package nta.med.service.helper;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import com.google.common.io.Files;


public class GenerateHanlderForVerticle {
	final static Log LOGGER = LogFactory.getLog(GenerateHanlderForVerticle.class);
	final static String mainPath = "D:\\SourceCode\\MED\\CloudService\\";
	public static List<String> listHanlderName = new ArrayList<String>();
	public static void readProtoFile(String verticle) throws IOException{
		 BufferedReader br = new BufferedReader(new FileReader(mainPath + "med-service\\src\\main\\java\\nta\\med\\service\\helper\\file.txt"));
		    try {
		        String line = br.readLine();
		        while (line != null) {
		        	if(!line.contains("=")){
		        		String str[] = line.split(" ");
		        		for(String st : str){
		        			if(st.contains("Request")){
		        				String handlerName = st.substring(0,st.indexOf("Request"));
		        				System.out.println("vertx.eventBus().registerHandler("+ verticle +"ServiceProto."
		        						+ st.substring(0,st.lastIndexOf("{") > 0 ? st.lastIndexOf("{") : st.length() ) +".class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(" 
		        						+ handlerName+ "Handler.class));" );
		        				listHanlderName.add(handlerName);
		        			}
		        		}
		            }
       			 line = br.readLine();
		        }
		    }catch(IOException e){
		    	LOGGER.error(e.getMessage(),e);
			}finally {
		        br.close();
		    }
	}
	
	public static void writeHanlderFile(String module) throws IOException{
		String path = "nta.med.service.ihis.handler." + module.toLowerCase();
		for(String handler : listHanlderName){
			String pathFile = mainPath + "med-service\\src\\main\\java\\" + path.replace(".", "\\")+ "\\" + handler +"Handler.java";
			File file = new File(pathFile);
			Charset charset = Charset.forName("US-ASCII");
			try (BufferedWriter writer = Files.newWriter(file, charset)) {
				writer.write("package " +path +";");
				writer.write("\n");
				writer.write("\n");
				writer.write("import javax.annotation.Resource;                                                                                 ");
				writer.write("\n");
				writer.write("import nta.med.common.remoting.rpc.protobuf.Rpc;                                                                                    ");
				writer.write("\n");
				writer.write("import nta.med.core.proto.util.RpcMessageBuilder;                                                                     ");
				writer.write("\n");
				writer.write("import nta.med.data.dao.medi.cpl.Cpl0108Repository;                                                               ");
				writer.write("\n");
				writer.write("import nta.med.service.ScreenHandler;                                                                             ");
				writer.write("\n");
				writer.write("import nta.med.service.ihis.proto."+ module +"ServiceProto;                                                        ");
				writer.write("\n");
				writer.write("\n");
				writer.write("import org.apache.commons.logging.Log;                                                                            ");
				writer.write("\n");
				writer.write("import org.apache.commons.logging.LogFactory;                                                                     ");
				writer.write("\n");
				writer.write("import org.springframework.context.annotation.Scope;                                                              ");
				writer.write("\n");
				writer.write("import org.springframework.stereotype.Service;                                                                    ");
				writer.write("\n");
				writer.write("import org.vertx.java.core.Handler;                                                                               ");
				writer.write("\n");
				writer.write("import org.vertx.java.core.eventbus.Message;                                                                      ");
				writer.write("\n");
				writer.write("\n");
				writer.write("import com.google.protobuf.InvalidProtocolBufferException;                                                         ");
				writer.write("\n");
				writer.write("\n");
				writer.write("@Service                                                                                                          ");
				writer.write("\n");
				writer.write("@Scope("+ '"'+ "prototype"+ '"'+")                                                                                 ");
				writer.write("\n");
				writer.write("public class "+ handler +"Handler extends ScreenHandler implements Handler<Message<byte[]>> {                     ");
				writer.write("\n");
				writer.write("	private static final Log LOGGER = LogFactory.getLog("+handler +"Handler.class);                                    ");
				writer.write("\n");
				writer.write("	@Resource                                                                                                       ");
				writer.write("\n");
				writer.write("	private Cpl0108Repository cpl0108Repository;                                                                    ");
				writer.write("\n");
				writer.write("	                                                                                                                ");
				writer.write("\n");
				writer.write("	@Override                                                                                                       ");
				writer.write("\n");
				writer.write("	public void handle(Message<byte[]> message) {                                                                   ");
				writer.write("\n");
				writer.write("        Rpc.RpcMessage rpcMessage;																															");
				writer.write("\n"); 
				writer.write("        try {                                                                                                                                                 ");
				writer.write("\n"); 
				writer.write("    		LOGGER.info("+ '"'+ "[START] "+ handler +"Handler"+ '"'+ ");                                                                                               ");
				writer.write("\n"); 
				writer.write("        	rpcMessage = Rpc.RpcMessage.parseFrom(message.body());                                                                                              ");
				writer.write("\n"); 
				writer.write("			Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);                                                                              ");
				writer.write("\n"); 
				writer.write("   	      	"+ module +"ServiceProto." + handler + "Request request =" + module +"ServiceProto." + handler + "Request.parseFrom(rpcMessage.getPayloadData());     ");
				writer.write("\n"); 
				writer.write("			LOGGER.info("+ '"'+ "REQUEST : "+ '"'+ "+ request.toString());                                                                                                     ");
				writer.write("\n"); 
				writer.write(" //     	   	"+ module +"ServiceProto." + handler + "Response.Builder response = "+ module +"ServiceProto." + handler + "Response.newBuilder();                      ");
				writer.write("\n"); 
				writer.write("			try {                                                                                                                                               ");
				writer.write("\n"); 
				writer.write(" // 				LOGGER.info("+ '"'+ "RESPONSE :"+ '"'+ " + response.build().toString());                                                                                        ");
				writer.write("\n"); 
				writer.write("//  				rpcBuilder.setPayloadClass("+ module +"ServiceProto." + handler + "Response.class.getSimpleName());                                              ");
				writer.write("\n"); 
				writer.write(" // 			    rpcBuilder.setPayloadData(response.build().toByteString());                                                                                     ");
				writer.write("\n"); 
				writer.write("			} catch (Exception e) {                                                                                                                             ");
				writer.write("\n"); 
				writer.write("				rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);                                                                                      ");
				writer.write("\n"); 
				writer.write("            	LOGGER.error(e.getMessage(),e);                                                                                                                 ");
				writer.write("\n"); 
				writer.write("			}finally{                                                                                                                                           ");
				writer.write("\n"); 
				writer.write("				message.reply(rpcBuilder.build().toByteArray());                                                                                                ");
				writer.write("\n"); 
				writer.write("		        LOGGER.info("+ '"'+ "[END] "+ handler +"Handler"+ '"'+ ");                                                                                            ");
				writer.write("\n"); 
				writer.write("			}                                                                                                                                                   ");
				writer.write("\n"); 
				writer.write("		} catch (InvalidProtocolBufferException e) {                                                                                                            ");
				writer.write("\n"); 
				writer.write("			LOGGER.error("+ '"'+ handler +"Handler :"+ '"'+ "+ e.getMessage(), e);	                                                                                    ");
				writer.write("\n"); 
				writer.write("		}																																						");
				writer.write("\n"); 
				writer.write("}                                                                                                                 ");
				writer.write("\n");
				writer.write("}");   
			} catch (IOException e) {
				LOGGER.error(e.getMessage(),e);
			}
		}
	}
	
	public static void writeTestFile(String module) throws IOException{
	//	String path = "nta.med.service.integration.ihis." + module.toLowerCase();
		String path = "nta.med.service.integration.ihis";
		for(String handler : listHanlderName){
			String pathFile = mainPath + "med-service\\src\\test\\java\\" + path.replace(".", "\\")+ "\\" + handler +"Test.java";
			File file = new File(pathFile);
			Charset charset = Charset.forName("US-ASCII");
			try (BufferedWriter writer = Files.newWriter(file, charset)) {
				writer.write("package " +path +";");	
				writer.write("\n");
				writer.write("\n");
				writer.write("import java.util.concurrent.CountDownLatch;                                                                                "); 
				writer.write("\n");
				writer.write("import java.util.concurrent.TimeUnit;                                                                                      "); 
				writer.write("\n");
				writer.write("import nta.med.common.remoting.rpc.protobuf.Rpc;																							   ");
				writer.write("\n");
				writer.write("import nta.med.service.ihis.proto."+ module +"ServiceProto;"                                                                  ); 
				writer.write("\n");
				writer.write("import org.junit.Test;                                                                                                     "); 
				writer.write("\n");
				writer.write("import org.junit.runner.RunWith;                                                                                           "); 
				writer.write("\n");
				writer.write("import org.springframework.beans.factory.annotation.Autowired;                                                             "); 
				writer.write("\n");
				writer.write("import org.springframework.test.context.ContextConfiguration;                                                              "); 
				writer.write("\n");
				writer.write("import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;                                                    "); 
				writer.write("\n");
				writer.write("import org.vertx.java.core.Handler;                                                                                        "); 
				writer.write("\n");
				writer.write("import org.vertx.java.core.Vertx;                                                                                          "); 
				writer.write("\n");
				writer.write("import org.vertx.java.core.eventbus.Message;                                                                               "); 
				writer.write("\n");
				writer.write("\n");
				writer.write("@RunWith(SpringJUnit4ClassRunner.class)                                                                                    "); 
				writer.write("\n");
				writer.write("@ContextConfiguration(locations = { "+'"'+"classpath:META-INF/spring/spring-master.xml" +'"'+" })                          "); 
				writer.write("\n");
				writer.write("public class " + handler +"Test {                                                                                          "); 
				writer.write("\n");
				writer.write("	@Autowired                                                                                                             "); 
				writer.write("\n");
				writer.write("	protected Vertx vertx;                                                                                                 "); 
				writer.write("\n");
				writer.write("\n");
				writer.write("	@Test                                                                                                                  "); 
				writer.write("\n");
				writer.write("	public void Test() throws InterruptedException {                                                            "); 
				writer.write("\n");
				writer.write("  		"	 +		module +"ServiceProto." + handler + "Request request =" + module + "ServiceProto." +  handler + "Request"            ); 
				writer.write("\n");
				writer.write("					.newBuilder()                                                                                              "); 
				writer.write("\n");
				writer.write("					.build();                                                                                                  "); 
				writer.write("\n");
				writer.write("\n");
				writer.write("			Rpc.RpcMessage rpcMessage = Rpc.RpcMessage                                                                         "); 
				writer.write("\n");
				writer.write("					.newBuilder()                                                                                              "); 
				writer.write("\n");
				writer.write("					.setId(System.currentTimeMillis())                                                                         "); 
				writer.write("\n");
				writer.write("					.setService("+'"'+"patientInsurance "+'"'+")                                                               "); 
				writer.write("\n");
				writer.write("					.setVersion("+'"'+"1.0.0"+'"'+")                                                                           "); 
				writer.write("\n");
				writer.write("					.setPayloadClass(                                                                                          "); 
				writer.write("\n");  
				writer.write("							" + module +"ServiceProto." + handler + "Request.class                                             "); 
				writer.write("\n"); 
				writer.write("									.getSimpleName())                                                                          "); 
				writer.write("\n");
				writer.write("					.setPayloadData(request.toByteString()).build();                                                           "); 
				writer.write("\n");
				writer.write("\n");
				writer.write("			final CountDownLatch latch = new CountDownLatch(1);                                                                "); 
				writer.write("\n");
				writer.write("			vertx.eventBus()                                                                                                   "); 
				writer.write("\n");
				writer.write("					.send(" + module +"ServiceProto." + handler + "Request.class                                               "); 
				writer.write("\n");
				writer.write("							.getSimpleName(),                                                                                  "); 
				writer.write("\n");
				writer.write("							rpcMessage.toByteArray(),                                                                          "); 
				writer.write("\n");
				writer.write("							new Handler<Message<byte[]>>() {                                                                   "); 
				writer.write("\n");
				writer.write("								@Override                                                                                      "); 
				writer.write("\n");
				writer.write("								public void handle(Message<byte[]> event) {                                                    "); 
				writer.write("\n");
				writer.write("									System.out.println("+'"'+"Success!"+'"'+");                                                "); 
				writer.write("\n");
				writer.write("									latch.countDown();                                                                         "); 
				writer.write("\n");
				writer.write("								}                                                                                              "); 
				writer.write("\n");
				writer.write("							});                                                                                                "); 
				writer.write("\n");
				writer.write("			latch.await(100, TimeUnit.SECONDS);                                                                                "); 
				writer.write("\n");
				writer.write("		}                                                                                                                      "); 
				writer.write("\n");
				writer.write("	}                                                                                                                          ");  

			} catch (IOException e) {
				LOGGER.error(e.getMessage(),e);
			}
		}
	}
	public static void main(String[] args) throws IOException {
		String module = "Bass";
		readProtoFile(module);
		writeHanlderFile(module);
//		writeTestFile(module);
	}
}
