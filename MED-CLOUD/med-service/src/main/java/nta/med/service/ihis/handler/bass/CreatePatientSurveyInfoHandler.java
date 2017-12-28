package nta.med.service.ihis.handler.bass;

import java.math.BigInteger;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.model.ihis.bass.CreatePatientSurveyInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.CreatePatientSurveyRequest;
import nta.med.service.ihis.proto.BassServiceProto.CreatePatientSurveyResponse;

@Service
@Scope("prototype")
public class CreatePatientSurveyInfoHandler extends ScreenHandler<BassServiceProto.CreatePatientSurveyRequest, BassServiceProto.CreatePatientSurveyResponse>{

	private static final Log LOGGER = LogFactory.getLog(CreatePatientSurveyInfoHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	public CreatePatientSurveyResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CreatePatientSurveyRequest request) throws Exception {

		BassServiceProto.CreatePatientSurveyResponse.Builder response = BassServiceProto.CreatePatientSurveyResponse.newBuilder();
		List<CreatePatientSurveyInfo> listData = out1001Repository.getPatientSurveyInfo(request.getHospCode());
		
		if(!CollectionUtils.isEmpty(listData)){
			for(CreatePatientSurveyInfo item : listData){
				BassModelProto.CreatePatientSurveyInfo.Builder info = BassModelProto.CreatePatientSurveyInfo.newBuilder();
				info.setPatientCode(item.getBunho() == null ? "" : item.getBunho());
				info.setPatientName(item.getSuname() == null ? "" : item.getSuname());
				info.setDepartmentCode(item.getGwa() == null ? "" : item.getGwa());
				info.setDepartmentName(item.getGwaName() ==  null ? "" : item.getGwaName());
				info.setReservationDate(item.getNaewonDate() ==  null ? "" : item.getNaewonDate());
				info.setReservationTime(item.getJubsuTime() ==  null ? "" : item.getJubsuTime());
				info.setReservationCode(item.getPkout1001() ==  null ? "" : item.getPkout1001());
				info.setPatientPwd(item.getPwd() ==  null ? "" : item.getPwd());
				
				response.addItem(info);
			}
		}
		return response.build();
	}
}

