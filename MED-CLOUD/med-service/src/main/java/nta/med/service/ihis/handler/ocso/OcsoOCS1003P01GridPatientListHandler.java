package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridPatientListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01GridPatientListHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GridPatientListRequest, OcsoServiceProto.OcsoOCS1003P01GridPatientListResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GridPatientListHandler.class);

	@Resource
	private	Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GridPatientListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GridPatientListRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GridPatientListResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GridPatientListResponse.newBuilder();
		List<OcsoOCS1003P01GridPatientListInfo> listObject = out1001Repository.getOcsoOCS1003P01GridPatientListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getNaewonDate(),
				request.getNaewonYn(), request.getReserYn(), request.getDoctorModeYn(), request.getDoctor(), request.getBunho());
		if (listObject != null && !listObject.isEmpty()) {
			for (OcsoOCS1003P01GridPatientListInfo obj : listObject) {
				OcsoModelProto.OcsoOCS1003P01GridPatientListInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01GridPatientListInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getBunho())) {
					itemBuilder.setBunho(obj.getBunho());
				}
				if (!StringUtils.isEmpty(obj.getNaewonDate())) {
					itemBuilder.setNaewonDate(obj.getNaewonDate().toString());
				}
				if (!StringUtils.isEmpty(obj.getGwa())) {
					itemBuilder.setGwa(obj.getGwa());
				}
				if (!StringUtils.isEmpty(obj.getDoctor())) {
					itemBuilder.setDoctor(obj.getDoctor());
				}
				if (!StringUtils.isEmpty(obj.getNaewonType())) {
					itemBuilder.setNaewonType(obj.getNaewonType());
				}
				if (!StringUtils.isEmpty(obj.getReserYn())) {
					itemBuilder.setReserYn(obj.getReserYn());
				}
				//
				if (!StringUtils.isEmpty(obj.getJubsuTime())) {
					itemBuilder.setJubsuTime(obj.getJubsuTime());
				}
				if (!StringUtils.isEmpty(obj.getArriveTime())) {
					itemBuilder.setArriveTime(obj.getArriveTime());
				}
				if (!StringUtils.isEmpty(obj.getSuname())) {
					itemBuilder.setSuname(obj.getSuname());
				}
				if (!StringUtils.isEmpty(obj.getSuname2())) {
					itemBuilder.setSuname2(obj.getSuname2());
				}
				if (!StringUtils.isEmpty(obj.getSex())) {
					itemBuilder.setSex(obj.getSex());
				}
				if (!StringUtils.isEmpty(obj.getAge())) {
					itemBuilder.setAge(obj.getAge().toString());
				}
				if (!StringUtils.isEmpty(obj.getGubunName())) {
					itemBuilder.setGubunName(obj.getGubunName());
				}
				if (!StringUtils.isEmpty(obj.getGwaName())) {
					itemBuilder.setGwaName(obj.getGwaName());
				}
				if (!StringUtils.isEmpty(obj.getDoctorName())) {
					itemBuilder.setDoctorName(obj.getDoctorName());
				}
				if (!StringUtils.isEmpty(obj.getChojaeName())) {
					itemBuilder.setChojaeName(obj.getChojaeName());
				}
				//
				if (!StringUtils.isEmpty(obj.getJinryoEndYn())) {
					itemBuilder.setJinryoEndYn(obj.getJinryoEndYn());
				}
				if (!StringUtils.isEmpty(obj.getPkNaewon())) {
					itemBuilder.setPkNaewon(obj.getPkNaewon().toString());
				}
				if (!StringUtils.isEmpty(obj.getNaewonYn())) {
					itemBuilder.setNaewonYn(obj.getNaewonYn());
				}
				if (!StringUtils.isEmpty(obj.getSunnabYn())) {
					itemBuilder.setSunnabYn(obj.getSunnabYn());
				}
				if (!StringUtils.isEmpty(obj.getJubsuGubun())) {
					itemBuilder.setJubsuGubun(obj.getJubsuGubun());
				}
				if (!StringUtils.isEmpty(obj.getOtherGwa())) {
					itemBuilder.setOtherGwa(obj.getOtherGwa());
				}
				if (!StringUtils.isEmpty(obj.getConsultYn())) {
					itemBuilder.setConsultYn(obj.getConsultYn());
				}
				if (!StringUtils.isEmpty(obj.getCommonDoctorYn())) {
					itemBuilder.setCommonDoctorYn(obj.getCommonDoctorYn());
				}
				if (!StringUtils.isEmpty(obj.getGubun())) {
					itemBuilder.setGubun(obj.getGubun());
				}
				if (!StringUtils.isEmpty(obj.getGroupKey())) {
					itemBuilder.setGroupKey(obj.getGroupKey());
				}
				if (!StringUtils.isEmpty(obj.getKensaYn())) {
					itemBuilder.setKensaYn(obj.getKensaYn());
				}
				if (!StringUtils.isEmpty(obj.getUnapproveYn())) {
					itemBuilder.setUnapproveYn(obj.getUnapproveYn());
				}
				response.addGridPatientListItem(itemBuilder);
			}
		}
		return response.build();
	}
}
