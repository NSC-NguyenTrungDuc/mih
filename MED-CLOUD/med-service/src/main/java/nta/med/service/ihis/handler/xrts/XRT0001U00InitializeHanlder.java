//package nta.med.service.ihis.handler.xrts;
//
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.core.utils.BeanUtils;
//import nta.med.data.dao.medi.xrt.Xrt0001Repository;
//import nta.med.data.dao.medi.xrt.Xrt0002Repository;
//import nta.med.data.dao.medi.xrt.Xrt0102Repository;
//import nta.med.data.model.ihis.common.ComboListItemInfo;
//import nta.med.data.model.ihis.xrts.XRT0001U00GrdRadioListInfo;
//import nta.med.data.model.ihis.xrts.XRT0001U00GrdXRTInfo;
//import nta.med.service.ScreenHandler;
//import nta.med.service.ihis.proto.CommonModelProto;
//import nta.med.service.ihis.proto.XrtsModelProto;
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
//public class XRT0001U00InitializeHanlder extends ScreenHandler implements Handler<Message<byte[]>>{
//	private static final Log LOGGER = LogFactory.getLog(XRT0001U00InitializeHanlder.class);
//	@Resource
//	private Xrt0102Repository xrt0102Repository;
//	@Resource
//	private Xrt0002Repository xrt0002Repository; 
//	@Resource
//	private Xrt0001Repository xrt0001Repository;
//	@Override
//	public void handle(Message<byte[]> message) {
//		LOGGER.info("[START] XRT0001U00InitializeHanlder");
//        Rpc.RpcMessage rpcMessage;
//        try {
//        	 rpcMessage=Rpc.RpcMessage.parseFrom(message.body());
//				Rpc.RpcMessage.Builder rpcBuilder=RpcMessageBuilder.reply(rpcMessage);
//				XrtsServiceProto.XRT0001U00InitializeRequest request=XrtsServiceProto.XRT0001U00InitializeRequest.parseFrom(rpcMessage.getPayloadData());
//				 LOGGER.info("REQUEST : " + request.toString());
//				 XrtsServiceProto.XRT0001U00InitializeResponse.Builder response=XrtsServiceProto.XRT0001U00InitializeResponse.newBuilder();
//				try {
//					 //get Combo list item info
//					 List<ComboListItemInfo> listCombo=xrt0102Repository.getXRT0001U00InitializeComboListItemInfo(getHospitalCode(), getLanguage());
//					 if(listCombo != null && !listCombo.isEmpty()){
//						 for(ComboListItemInfo item: listCombo){
//							 CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
//							 if (!StringUtils.isEmpty(item.getCode())) {
//									info.setCode(item.getCode());
//								}
//								if (!StringUtils.isEmpty(item.getCodeName())) {
//									info.setCodeName(item.getCodeName());
//								}
//								response.addCbxXrayGubunList(info);
//						 }
//					 }
//					 //get grdRadio_list 
////					 List<XRT0001U00GrdRadioListInfo> listGrdRadio= xrt0002Repository.getXRT0001U00GrdRadioListItemInfo(getHospitalCode(),request.getXrayCodeGrdRadioList());
////					 if(listGrdRadio !=null && !listGrdRadio.isEmpty() ){
////						 for(XRT0001U00GrdRadioListInfo item : listGrdRadio){
////							 XrtsModelProto.XRT0001U00GrdRadioListItemInfo.Builder info= XrtsModelProto.XRT0001U00GrdRadioListItemInfo.newBuilder();
////							 	BeanUtils.copyProperties(item, info);
////								response.addGrdRadioList(info);
////						 }
////					 }
//					 //get grdXRT_list 
//					 List<XRT0001U00GrdXRTInfo> listGrdXrt= xrt0001Repository.getXRT0001U00GrdXRTListItemInfo(getHospitalCode(),getLanguage(),request.getTxtParamGrdXRT(),request.getXrayGubunGrdXRT(),request.getSpecialYnGrdXRT());
//					 if(listGrdXrt !=null && !listGrdXrt.isEmpty()){
//						 for(XRT0001U00GrdXRTInfo item :listGrdXrt){
//							 XrtsModelProto.XRT0001U00GrdXRTListItemInfo.Builder info= XrtsModelProto.XRT0001U00GrdXRTListItemInfo.newBuilder();
//							 	BeanUtils.copyProperties(item, info);
//								response.addGrdXRTList(info);
//						 }
//					 }
//					 //get y_value_layDup 
//					 String getYValueLayDup= xrt0001Repository.getYValueLayDupXRT0001U00Initialize(getHospitalCode(),request.getXrayCodeLayDup());
//					 if(!StringUtils.isEmpty(getYValueLayDup)){
//						 response.setYValueLayDup(getYValueLayDup);
//					 }
//					 	LOGGER.info("RESPONSE: " + response.build().toString());
//						rpcBuilder.setPayloadClass(XrtsServiceProto.XRT0001U00InitializeResponse.class.getSimpleName());
//						rpcBuilder.setPayloadData(response.build().toByteString());
//				} catch (Exception e) {
//					rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);                                                                                      
//	            	LOGGER.error(e.getMessage(),e);   
//				}finally{
//					message.reply(rpcBuilder.build().toByteArray());
//				}
//		} catch (InvalidProtocolBufferException e) {
//			LOGGER.error(" XRT0001U00InitializeHanlder "+e.getMessage(), e);
//		}
//        LOGGER.info("[END] XRT0001U00InitializeHanlder");
//	}
//}
