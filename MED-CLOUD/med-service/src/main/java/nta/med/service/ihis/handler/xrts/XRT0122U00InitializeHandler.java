//package nta.med.service.ihis.handler.xrts;
//
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.core.utils.BeanUtils;
//import nta.med.data.dao.medi.xrt.Xrt0121Repository;
//import nta.med.data.model.ihis.xrts.XRT0122U00InitializeInfo;
//import nta.med.service.ScreenHandler;
//import nta.med.service.ihis.proto.XrtsModelProto;
//import nta.med.service.ihis.proto.XrtsServiceProto;
//
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.util.CollectionUtils;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.eventbus.Message;
//
//import com.google.protobuf.InvalidProtocolBufferException;
//
//@Service                                                                                                          
//@Scope("prototype")                                                                                 
//public class XRT0122U00InitializeHandler extends ScreenHandler implements Handler<Message<byte[]>> {                             
//	private static final Log LOGGER = LogFactory.getLog(XRT0122U00InitializeHandler.class);                                        
//	@Resource                                                                                                       
//	private Xrt0121Repository xrt0121Repository;                                                                    
//	                                                                                                                
//	@Override                                                                                                       
//	public void handle(Message<byte[]> message) {
//        Rpc.RpcMessage rpcMessage;
//        try {
//    		LOGGER.info("[START] XRT0122U00InitializeHandler");
//        	rpcMessage = Rpc.RpcMessage.parseFrom(message.body());
//			Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);
//			XrtsServiceProto.XRT0122U00InitializeRequest request = XrtsServiceProto.XRT0122U00InitializeRequest.parseFrom(rpcMessage.getPayloadData());
//			LOGGER.info("REQUEST : " + request.toString());
//			XrtsServiceProto.XRT0122U00InitializeResponse.Builder response=XrtsServiceProto.XRT0122U00InitializeResponse.newBuilder();
//			try {
//				List<XRT0122U00InitializeInfo> listResult=xrt0121Repository.getInitializeItem(getHospitalCode(), request.getBuwiBunryu());
//				if(!CollectionUtils.isEmpty(listResult)){
//					for(XRT0122U00InitializeInfo item : listResult){
//						XrtsModelProto.XRT0122U00grdMCodeListItemInfo.Builder info = XrtsModelProto.XRT0122U00grdMCodeListItemInfo.newBuilder();
//						BeanUtils.copyProperties(item, info);
//						response.addInitializeInfo(info);
//					}
//				}
//				LOGGER.info("RESPONSE: " + response.build().toString());
//				rpcBuilder.setPayloadClass(XrtsServiceProto.XRT0001U00FbxDataValidatingSelectXRT0122Response.class.getSimpleName());
//				rpcBuilder.setPayloadData(response.build().toByteString());
//			} catch (Exception e) {
//				LOGGER.error(e.getMessage(),e);
//            	rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);
//			}finally{
//				message.reply(rpcBuilder.build().toByteArray());
//				LOGGER.info("[END] XRT0122U00InitializeHandler");
//			}
//		} catch (InvalidProtocolBufferException e) {
//			LOGGER.error(e.getMessage(), e);
//		}
//	}                                                                                                               
//}                                                                                                                 
