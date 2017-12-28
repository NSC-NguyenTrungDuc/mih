//package nta.med.service.ihis.handler.xrts;
//
//import java.util.Date;
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.core.domain.xrt.Xrt0002;
//import nta.med.core.enums.DataRowState;
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.data.dao.medi.xrt.Xrt0002Repository;
//import nta.med.service.ScreenHandler;
//import nta.med.service.ihis.proto.XrtsServiceProto;
//
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.transaction.annotation.Transactional;
//import org.springframework.util.CollectionUtils;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.eventbus.Message;
//
//import com.google.protobuf.InvalidProtocolBufferException;
//
//@Transactional
//@Service
//@Scope("prototype")
//public class XRT0001U00ExecuteCase2Handler extends ScreenHandler implements Handler<Message<byte[]>>{
//	private static final Log LOGGER = LogFactory.getLog(XRT0001U00ExecuteCase2Handler.class);
//	@Resource
//	private Xrt0002Repository xrt0002Repository;
//	@Override
//	public void handle(Message<byte[]> message) {
//		LOGGER.info("[START] XRT0001U00ExecuteCase2Handler");
//        Rpc.RpcMessage rpcMessage;
//        try {
//        	 rpcMessage=Rpc.RpcMessage.parseFrom(message.body());
//				Rpc.RpcMessage.Builder rpcBuilder=RpcMessageBuilder.reply(rpcMessage);
//				XrtsServiceProto.XRT0001U00ExecuteCase2Request request=XrtsServiceProto.XRT0001U00ExecuteCase2Request.parseFrom(rpcMessage.getPayloadData());
//				 LOGGER.info("REQUEST : " + request.toString());
//				 XrtsServiceProto.UpdateRespone.Builder response=XrtsServiceProto.UpdateRespone.newBuilder();
//				try {
//					Integer result = null;
//					 if(DataRowState.ADDED.getValue().equals(request.getRowState())){
//						 result=insertXrt0002(request);
//					 }else if(DataRowState.MODIFIED.getValue().equals(request.getRowState())){
//						 result=updateXrt0002(request);
//					 }else if(DataRowState.DELETED.getValue().equals(request.getRowState())){
//						result= xrt0002Repository.deleteXRT0001U00ExecuteCase2(getHospitalCode(),request.getXrayCode(),request.getXrayCodeIdx());
//					 }
//					 response.setResult(result != null && result > 0);
//					 LOGGER.info("RESPONSE: " + response.build().toString());
//					rpcBuilder.setPayloadClass(XrtsServiceProto.UpdateRespone.class.getSimpleName());
//					rpcBuilder.setPayloadData(response.build().toByteString());
//				} catch (Exception e) {
//					rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);   
//					LOGGER.error(e.getMessage(),e); 
//				}finally{
//					message.reply(rpcBuilder.build().toByteArray());
//				}
//		} catch (InvalidProtocolBufferException e) {
//			LOGGER.error(" XRT0001U00ExecuteCase2Handler "+e.getMessage(), e);		
//		}
//        LOGGER.info("[END] XRT0001U00ExecuteCase2Handler");
//	}
//	private Integer insertXrt0002(XrtsServiceProto.XRT0001U00ExecuteCase2Request request){
//		try {
//			Xrt0002 xrt0002 = new Xrt0002();
//			xrt0002.setSysDate(new Date());
//			xrt0002.setUpdId(request.getUserId());
//			xrt0002.setUpdDate(new Date());
//			xrt0002.setHospCode(getHospitalCode());
//			xrt0002.setXrayCode(request.getXrayCode());
//			xrt0002.setXrayGubun(request.getXrayGubun());
//			xrt0002.setXrayCodeIdx(request.getXrayCodeIdx());
//			xrt0002.setXrayCodeIdxNm(request.getXrayCodeIdxNm());
//			xrt0002.setTubeVol(request.getTubeVol());
//			xrt0002.setTubeCur(request.getTubeCur());
//			xrt0002.setXrayTime(request.getXrayTime());
//			xrt0002.setTubeCurTime(request.getTubeCurTime());
//			xrt0002.setIrradiationTime(request.getIrradiationTime());
//			xrt0002.setXrayDistance(request.getXrayDistance());
//			xrt0002Repository.save(xrt0002);
//			return 1;
//		} catch (Exception e) {
//			LOGGER.error("Error on insertXrt0101 "+e.getMessage(), e);
//			return 0;
//		}
//	}
//	private Integer updateXrt0002(XrtsServiceProto.XRT0001U00ExecuteCase2Request request){
//		try {
//			List<Xrt0002> listXrt0002 =xrt0002Repository.getObjectXrt0002ExecuteCase2(getHospitalCode(),request.getXrayCode(),request.getXrayCodeIdx());
//			if(!CollectionUtils.isEmpty(listXrt0002)) {
//				for(Xrt0002 xrt0002 : listXrt0002) {
//					xrt0002.setUpdId(request.getUserId());
//					xrt0002.setUpdDate(new Date());
//					xrt0002.setHospCode(getHospitalCode());
//					xrt0002.setXrayCode(request.getXrayCode());
//					xrt0002.setXrayGubun(request.getXrayGubun());
//					xrt0002.setXrayCodeIdx(request.getXrayCodeIdx());
//					xrt0002.setXrayCodeIdxNm(request.getXrayCodeIdxNm());
//					xrt0002.setTubeVol(request.getTubeVol());
//					xrt0002.setTubeCur(request.getTubeCur());
//					xrt0002.setXrayTime(request.getXrayTime());
//					xrt0002.setTubeCurTime(request.getTubeCurTime());
//					xrt0002.setIrradiationTime(request.getIrradiationTime());
//					xrt0002.setXrayDistance(request.getXrayDistance());
//				}
//			}
//			xrt0002Repository.save(listXrt0002);
//			return 1;
//		} catch (Exception e) {
//			LOGGER.error("Error on insertXrt0101 "+e.getMessage(), e);
//			return 0;
//		}
//	}
//}
