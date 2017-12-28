//package nta.med.service.ihis.handler.xrts;
//
//import javax.annotation.Resource;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.data.dao.medi.xrt.Xrt0102Repository;
//import nta.med.service.ScreenHandler;
//import nta.med.service.ihis.proto.XrtsServiceProto;
//
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.transaction.annotation.Transactional;
//import org.springframework.util.StringUtils;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.eventbus.Message;
//
//import com.google.protobuf.InvalidProtocolBufferException;
//
//@Transactional
//@Service
//@Scope("prototype")
//public class XRT0001U00FbxDataValidatingSelectXRT0102Handler extends ScreenHandler implements Handler<Message<byte[]>>{
//	private static final Log LOGGER = LogFactory.getLog(XRT0001U00FbxDataValidatingSelectXRT0102Handler.class);
//	@Resource
//	private Xrt0102Repository xrt0102Repository;
//	@Override
//	public void handle(Message<byte[]> message) {
//		LOGGER.info("[START] XRT0001U00FbxDataValidatingSelectXRT0102Handler");
//        Rpc.RpcMessage rpcMessage;
//        try {
//        	rpcMessage=Rpc.RpcMessage.parseFrom(message.body());
//			Rpc.RpcMessage.Builder rpcBuilder=RpcMessageBuilder.reply(rpcMessage);
//			XrtsServiceProto.XRT0001U00FbxDataValidatingSelectXRT0102Request request=XrtsServiceProto.XRT0001U00FbxDataValidatingSelectXRT0102Request.parseFrom(rpcMessage.getPayloadData());
//			 LOGGER.info("REQUEST : " + request.toString());
//			 XrtsServiceProto.XRT0001U00FbxDataValidatingSelectXRT0102Response.Builder response=XrtsServiceProto.XRT0001U00FbxDataValidatingSelectXRT0102Response.newBuilder();
//			 try {
//				 String getFbxData= xrt0102Repository.getXRT0001U00FbxDataValidatingSelectXRT0102(getHospitalCode(),getLanguage(),request.getCodeType(),request.getCode());
//				 if(!StringUtils.isEmpty(getFbxData)){
//					 response.setCodeName(getFbxData);
//				 }
//				 	LOGGER.info("RESPONSE: " + response.build().toString());
//					rpcBuilder.setPayloadClass(XrtsServiceProto.XRT0001U00FbxDataValidatingSelectXRT0102Response.class.getSimpleName());
//					rpcBuilder.setPayloadData(response.build().toByteString());
//			} catch (Exception e) {
//				rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);                                                                                      
//            	LOGGER.error(e.getMessage(),e);
//			}finally{
//				message.reply(rpcBuilder.build().toByteArray());
//			}
//		} catch (InvalidProtocolBufferException e) {
//			LOGGER.error(" XRT0001U00FbxDataValidatingSelectXRT0102Handler "+e.getMessage(), e);
//		}
//        LOGGER.info("[END] XRT0001U00FbxDataValidatingSelectXRT0102Handler");
//	}
//}
