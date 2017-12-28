package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.OCS1003P01GrdPatientListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.NotApproveOrderCntInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003P01GrdPatientHandler extends ScreenHandler<NuroServiceProto.OCS1003P01GrdPatientRequest, NuroServiceProto.OCS1003P01GrdPatientResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01GrdPatientHandler.class);                                        
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(NuroServiceProto.OCS1003P01GrdPatientRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional
	public NuroServiceProto.OCS1003P01GrdPatientResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OCS1003P01GrdPatientRequest request) throws Exception {
		NuroServiceProto.OCS1003P01GrdPatientResponse.Builder response = NuroServiceProto.OCS1003P01GrdPatientResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS1003P01GrdPatientListItemInfo> listResult = out1001Repository.getOCS1003P01GrdPatientListItem(hospCode, DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), 
				request.getNaewonYn(), request.getReserYn(),request.getDoctorModeYn(), request.getDoctor(), request.getBunho(), language);
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS1003P01GrdPatientListItemInfo item : listResult){
				NuroModelProto.OCS1003P01GrdPatientListItemInfo.Builder info = NuroModelProto.OCS1003P01GrdPatientListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getBunho())) {
					info.setBunho(item.getBunho());
				}
				if (!StringUtils.isEmpty(item.getNaewonDate())) {
					info.setNaewonDate(item.getNaewonDate().toString());
				}
				if (!StringUtils.isEmpty(item.getGwa())) {
					info.setGwa(item.getGwa());
				}
				if (!StringUtils.isEmpty(item.getDoctor())) {
					info.setDoctor(item.getDoctor());
				}
				if (!StringUtils.isEmpty(item.getNaewonType())) {
					info.setNaewonType(item.getNaewonType());
				}
				if (!StringUtils.isEmpty(item.getReserYn())) {
					info.setReserYn(item.getReserYn());
				}
				if (!StringUtils.isEmpty(item.getJubsuTime())) {
					info.setJubsuTime(item.getJubsuTime());
				}
				if (!StringUtils.isEmpty(item.getArriveTime())) {
					info.setArriveTime(item.getArriveTime());
				}
				if (!StringUtils.isEmpty(item.getSuname())) {
					info.setSuname(item.getSuname());
				}
				if (!StringUtils.isEmpty(item.getSuname2())) {
					info.setSuname2(item.getSuname2());
				}
				if (!StringUtils.isEmpty(item.getSex())) {
					info.setSex(item.getSex());
				}
				if (!StringUtils.isEmpty(item.getAge())) {
					info.setAge(item.getAge().toString());
				}
				if (!StringUtils.isEmpty(item.getGubunName())) {
					info.setGubunName(item.getGubunName());
				}
				if (!StringUtils.isEmpty(item.getGwaName())) {
					info.setGwaName(item.getGwaName());
				}
				if (!StringUtils.isEmpty(item.getDoctorName())) {
					info.setDoctorName(item.getDoctorName());
				}
				if (!StringUtils.isEmpty(item.getChojaeName())) {
					info.setChojaeName(item.getChojaeName());
				}
				if (!StringUtils.isEmpty(item.getJinryoEndYn())) {
					info.setJinryoEndYn(item.getJinryoEndYn());
				}
				if (!StringUtils.isEmpty(item.getPkNaewon())) {
					info.setPkNaewon(item.getPkNaewon().toString());
				}
				if (!StringUtils.isEmpty(item.getNaewonYn())) {
					info.setNaewonYn(item.getNaewonYn());
				}
				if (!StringUtils.isEmpty(item.getSunnabYn())) {
					info.setSunnabYn(item.getSunnabYn());
				}
				if (!StringUtils.isEmpty(item.getJubsuGubun())) {
					info.setJubsuGubun1(item.getJubsuGubun());
				}
				if (!StringUtils.isEmpty(item.getJubsuGubun())) {
					info.setJubsuGubun2(item.getJubsuGubun());
				}
				if (!StringUtils.isEmpty(item.getOtherGwa())) {
					info.setOtherGwa(item.getOtherGwa());
				}
				if (!StringUtils.isEmpty(item.getConsultYn())) {
					info.setConsultYn(item.getConsultYn());
				}
				if (!StringUtils.isEmpty(item.getCommonDoctorYn())) {
					info.setCommonDoctorYn(item.getCommonDoctorYn());
				}
				if (!StringUtils.isEmpty(item.getGubun())) {
					info.setGubun(item.getGubun());
				}
				if (!StringUtils.isEmpty(item.getGroupKey())) {
					info.setGroupKey(item.getGroupKey());
				}
				if (!StringUtils.isEmpty(item.getKensaYn())) {
					info.setKensaYn(item.getKensaYn());
				}
				if (!StringUtils.isEmpty(item.getUnapproveYn())) {
					info.setUnapproveYn(item.getUnapproveYn());
				}
				if (!StringUtils.isEmpty(item.getSysId())) {
					info.setSysId(item.getSysId());
				}
				response.addGrdPatientList(info);
			}
		}    
		NotApproveOrderCntInfo order = request.getOrderCnt();
		if(order != null){
			String cntValue = out1001Repository.callFnOcsGetNotapproveOrdercnt(hospCode, order.getIoGubun(), order.getInsteadYn(),
				order.getApproveYn(), order.getUserId(), order.getKey());
			if(!StringUtils.isEmpty(cntValue)){
				response.setCntValue(cntValue);	
			}
		}
		return response.build();
	}                                                                                                                 
}