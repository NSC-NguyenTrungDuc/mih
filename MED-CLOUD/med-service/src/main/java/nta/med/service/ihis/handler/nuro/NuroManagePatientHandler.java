package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroManagePatient;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroManagePatientHandler extends ScreenHandler<NuroServiceProto.NuroManagePatientRequest, NuroServiceProto.NuroManagePatientResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroManagePatientHandler.class);
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroManagePatientResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroManagePatientRequest request) throws Exception {
		NuroServiceProto.NuroManagePatientResponse.Builder response = NuroServiceProto.NuroManagePatientResponse.newBuilder();
		List<NuroManagePatient> listManagePatientInfo = out0101Repository.getNuroManagePatientInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getPatientCode());
		if (listManagePatientInfo != null && !listManagePatientInfo.isEmpty()) {
			for (NuroManagePatient obj : listManagePatientInfo) {
				NuroModelProto.NuroManagePatientInfo.Builder managePatientInfoBuiler = NuroModelProto.NuroManagePatientInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getPatientCode())) {
					managePatientInfoBuiler.setPatientCode(obj.getPatientCode());
				}
				if (!StringUtils.isEmpty(obj.getPatientName1())) {
					managePatientInfoBuiler.setPatientName1(obj.getPatientName1());
				}
				if (!StringUtils.isEmpty(obj.getPatientName2())) {
					managePatientInfoBuiler.setPatientName2(obj.getPatientName2());
				}
				if (obj.getBirth() != null) {
					managePatientInfoBuiler.setBirth(obj.getBirth().toString());
				}
				if (!StringUtils.isEmpty(obj.getSex())) {
					managePatientInfoBuiler.setSex(obj.getSex());
				}
				if (!StringUtils.isEmpty(obj.getZipCode1())) {
					managePatientInfoBuiler.setZipCode1(obj.getZipCode1());
				}
				if (!StringUtils.isEmpty(obj.getZipCode2())) {
					managePatientInfoBuiler.setZipCode2(obj.getZipCode2());
				}
				if (!StringUtils.isEmpty(obj.getAddress1())) {
					managePatientInfoBuiler.setAddress1(obj.getAddress1());
				}
				if (!StringUtils.isEmpty(obj.getAddress2())) {
					managePatientInfoBuiler.setAddress2(obj.getAddress2());
				}
				if (!StringUtils.isEmpty(obj.getTel())) {
					managePatientInfoBuiler.setTel(obj.getTel());
				}
				if (!StringUtils.isEmpty(obj.getTel1())) {
					managePatientInfoBuiler.setTel1(obj.getTel1());
				}
				if (!StringUtils.isEmpty(obj.getTelHp())) {
					managePatientInfoBuiler.setTelHp(obj.getTelHp());
				}
				if (!StringUtils.isEmpty(obj.getTelType())) {
					managePatientInfoBuiler.setTelType(obj.getTelType());
				}
				if (!StringUtils.isEmpty(obj.getTelType2())) {
					managePatientInfoBuiler.setTelType2(obj.getTelType2());
				}
				if (!StringUtils.isEmpty(obj.getTelType3())) {
					managePatientInfoBuiler.setTelType3(obj.getTelType3());
				}
				if (!StringUtils.isEmpty(obj.getEmail())) {
					managePatientInfoBuiler.setEMail(obj.getEmail());
				}
				if (!StringUtils.isEmpty(obj.getPaceMakerYn())) {
					managePatientInfoBuiler.setPaceMakerYn(obj.getPaceMakerYn());
				}
				if (!StringUtils.isEmpty(obj.getSelfPaceMaker())) {
					managePatientInfoBuiler.setSelfPaceMaker(obj.getSelfPaceMaker());
				}
				
				response.addManagePatientItem(managePatientInfoBuiler);
			}
		}
		return response.build();
	}

}
