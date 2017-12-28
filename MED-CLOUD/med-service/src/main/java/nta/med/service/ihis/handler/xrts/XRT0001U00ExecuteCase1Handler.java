//package nta.med.service.ihis.handler.xrts;
//
//import java.util.Date;
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.core.domain.xrt.Xrt0001;
//import nta.med.core.enums.DataRowState;
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.core.utils.CommonUtils;
//import nta.med.data.dao.medi.xrt.Xrt0001Repository;
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
//public class XRT0001U00ExecuteCase1Handler extends ScreenHandler implements Handler<Message<byte[]>>{
//	private static final Log LOGGER = LogFactory.getLog(XRT0001U00ExecuteCase1Handler.class);
//	@Resource
//	private Xrt0001Repository xrt0001Repository;
//	@Override
//	public void handle(Message<byte[]> message) {
//		LOGGER.info("[START] XRT0001U00FbxDataValidatingSelectXRT0122Handler");
//        Rpc.RpcMessage rpcMessage;
//        try {
//        	rpcMessage=Rpc.RpcMessage.parseFrom(message.body());
//			Rpc.RpcMessage.Builder rpcBuilder=RpcMessageBuilder.reply(rpcMessage);
//			XrtsServiceProto.XRT0001U00ExecuteCase1Request request=XrtsServiceProto.XRT0001U00ExecuteCase1Request.parseFrom(rpcMessage.getPayloadData());
//			 LOGGER.info("REQUEST : " + request.toString());
//			 XrtsServiceProto.UpdateRespone.Builder response=XrtsServiceProto.UpdateRespone.newBuilder();
//			 try {
//				 Integer result = null;
//				 if(DataRowState.ADDED.getValue().equals(request.getRowState())){
//						 result=insertXRT0001(request);
//				 }else if(DataRowState.MODIFIED.getValue().equals(request.getRowState())){
//					result=updateXrt0001(request);
//				 }else if(DataRowState.DELETED.getValue().equals(request.getRowState())){
//					 result=xrt0001Repository.deleteXRT0001U00ExecuteCase1(getHospitalCode(),request.getXrayCode());
//				 }
//				 response.setResult(result != null && result > 0);
//				 	LOGGER.info("RESPONSE: " + response.build().toString());
//					rpcBuilder.setPayloadClass(XrtsServiceProto.UpdateRespone.class.getSimpleName());
//					rpcBuilder.setPayloadData(response.build().toByteString());
//			} catch (Exception e) {
//				rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);   
//				LOGGER.error(e.getMessage(),e); 
//			}finally{
//				message.reply(rpcBuilder.build().toByteArray());
//			}
//		} catch (InvalidProtocolBufferException e) {
//			LOGGER.error(" XRT0001U00ExecuteCase1Handler "+e.getMessage(), e);		
//		}
//        LOGGER.info("[END] XRT0001U00ExecuteCase1Handler");
//	}
//	private Integer insertXRT0001(XrtsServiceProto.XRT0001U00ExecuteCase1Request request){
//		try {
//			Xrt0001 xrt0001= new Xrt0001();
//			xrt0001.setSysDate(new Date());
//			xrt0001.setSysId(request.getUserId());
//			xrt0001.setUpdDate(new Date());
//			xrt0001.setUpdId(request.getUserId());
//			xrt0001.setHospCode(getHospitalCode());
//			xrt0001.setXrayCode(request.getXrayCode());
//			xrt0001.setXrayName(request.getXrayName());
//			xrt0001.setXrayGubun(request.getXrayGubun());
//			xrt0001.setXrayRoom(request.getXrayRoom());
//			xrt0001.setXrayBuwi(request.getXrayBuwi());
//			xrt0001.setXrayBuwiKaikei(request.getXrayBuwiKaikei());
//			xrt0001.setXrayBuwiTong(request.getXrayBuwiTong());
//			xrt0001.setXrayCnt(CommonUtils.parseDouble(request.getXrayCnt()));
//			xrt0001.setNamePrintYn(request.getNamePrintYn());
//			xrt0001.setSugaCode(request.getSugaCode());
//			xrt0001.setSpecialYn(request.getSpecialYn());
//			xrt0001.setXrayName2(request.getXrayName2());
//			xrt0001.setXrayRealCnt(CommonUtils.parseDouble(request.getXrayRealCnt()));
//			xrt0001.setSlipCode(request.getSlipCode());
//			xrt0001.setReserType(request.getReserType());
//			xrt0001.setJaeryoYn(request.getJaeryoYn());
//			xrt0001.setSort(request.getSort());
//			xrt0001.setXrayWay(request.getXrayWay());
//			xrt0001.setTongGubun(request.getTongGubun());
//			xrt0001.setRequestYn(request.getRequestYn());
//			xrt0001.setModality(request.getModality());
//			xrt0001.setFrequentUseYn(request.getFrequentUseYn());
//			xrt0001.setTubeVol(request.getTubeVol());
//			xrt0001.setTubeCur(request.getTubeCur());
//			xrt0001.setXrayTime(request.getXrayTime());
//			xrt0001.setTubeCurTime(request.getTubeCurTime());
//			xrt0001.setIrradiationTime(request.getIrradiationTime());
//			xrt0001.setXrayDistance(request.getXrayDistance());
//			xrt0001Repository.save(xrt0001);
//			return 1;
//		} catch (Exception e) {
//			LOGGER.error("Error on insertXrt0101 "+e.getMessage(), e);
//			return 0;
//		}
//	}
//	private Integer updateXrt0001(XrtsServiceProto.XRT0001U00ExecuteCase1Request request){
//		try {
//			List<Xrt0001> listXrt0001 =xrt0001Repository.getObjectXrt0001ExecuteCase1(getHospitalCode(),request.getXrayCode());
//			if(!CollectionUtils.isEmpty(listXrt0001)) {
//				for(Xrt0001 xrt0001 : listXrt0001) {
//					xrt0001.setUpdId(request.getUserId());
//					xrt0001.setUpdDate(new Date());
//					xrt0001.setXrayName(request.getXrayName());
//					xrt0001.setXrayGubun(request.getXrayGubun());
//					xrt0001.setXrayRoom(request.getXrayRoom());
//					xrt0001.setXrayBuwi(request.getXrayBuwi());
//					xrt0001.setXrayBuwiKaikei(request.getXrayBuwiKaikei());
//					xrt0001.setXrayBuwiTong(request.getXrayBuwiTong());
//					xrt0001.setXrayCnt(CommonUtils.parseDouble(request.getXrayCnt()));
//					xrt0001.setNamePrintYn(request.getNamePrintYn());
//					xrt0001.setSugaCode(request.getSugaCode());
//					xrt0001.setSpecialYn(request.getSpecialYn());
//					xrt0001.setXrayName2(request.getXrayName2());
//					xrt0001.setXrayRealCnt(CommonUtils.parseDouble(request.getXrayRealCnt()));
//					xrt0001.setSlipCode(request.getSlipCode());
//					xrt0001.setReserType(request.getReserType());
//					xrt0001.setJaeryoYn(request.getJaeryoYn());
//					xrt0001.setSort(request.getSort());
//					xrt0001.setXrayWay(request.getXrayWay());
//					xrt0001.setTongGubun(request.getTongGubun());
//					xrt0001.setRequestYn(request.getRequestYn());
//					xrt0001.setModality(request.getModality());
//					xrt0001.setFrequentUseYn(request.getFrequentUseYn());
//					xrt0001.setTubeVol(request.getTubeVol());
//					xrt0001.setTubeCur(request.getTubeCur());
//					xrt0001.setXrayTime(request.getXrayTime());
//					xrt0001.setTubeCurTime(request.getTubeCurTime());
//					xrt0001.setIrradiationTime(request.getIrradiationTime());
//					xrt0001.setXrayDistance(request.getXrayDistance());
//				}
//			}
//			xrt0001Repository.save(listXrt0001);
//			return 1;
//		} catch (Exception e) {
//			LOGGER.error("Error on insertXrt0101 "+e.getMessage(), e);
//			return 0;
//		}
//	}
//}
