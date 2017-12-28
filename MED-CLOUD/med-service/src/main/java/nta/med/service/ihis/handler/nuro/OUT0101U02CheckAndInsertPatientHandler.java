package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out0101;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OUT0101U02CheckAndInsertPatientHandler extends ScreenHandler<NuroServiceProto.OUT0101U02CheckAndInsertPatientRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OUT0101U02CheckAndInsertPatientHandler.class);
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02CheckAndInsertPatientRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String  nuroOUT0101U02CheckExistsX = out0101Repository.getNuroOUT0101U02CheckExistsX(getHospitalCode(vertx, sessionId), hospCode);
		if("Y".equals(nuroOUT0101U02CheckExistsX)){
			response.setResult(false);
		}else{
			insertPatientHandler(request, hospCode);
			response.setResult(true);
		}
		return response.build();
	}
	
	private void insertPatientHandler(NuroServiceProto.OUT0101U02CheckAndInsertPatientRequest request, String hospCode) {
			Out0101 out0101 = new Out0101();
			Date date = new Date();
			out0101.setSysDate(date);
			out0101.setHospCode(hospCode);
			out0101.setSysId(request.getSysId());
			out0101.setUpdDate(date);
			out0101.setBunho(request.getPatientCode());
			out0101.setSuname(request.getPatientName());
			out0101.setSex(request.getSex());
			out0101.setBirth(DateUtil.toDate(request.getBirth(), DateUtil.PATTERN_YYMMDD));
			out0101.setZipCode1(request.getZipCode1());
			out0101.setZipCode2(request.getZipCode2());
			out0101.setAddress1(request.getAddress1());
			out0101.setAddress2(request.getAddress2());
			out0101.setTel(request.getTel());
			out0101.setTel1(request.getTel1());
			out0101.setTelGubun(request.getTelType());
			out0101.setTelGubun2(request.getTelType2());
			out0101.setTelGubun3(request.getTelType3());
			out0101.setDeleteYn(request.getDeleteYn());
			out0101.setPaceMakerYn(request.getPaceMakerYn());
			out0101.setSelfPaceMaker(request.getSelfPaceMaker());
			out0101.setBunhoType(request.getPatientType());
			out0101Repository.save(out0101);
	}
	
}
