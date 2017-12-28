package nta.med.service.ihis.handler.clis;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.clis.CLIS2015U03PatientListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03SearchPatientRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03SearchPatientResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CLIS2015U03SearchPatientHandler extends ScreenHandler<ClisServiceProto.CLIS2015U03SearchPatientRequest, ClisServiceProto.CLIS2015U03SearchPatientResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U03SearchPatientHandler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;        
	
	@Override
	public boolean isValid(ClisServiceProto.CLIS2015U03SearchPatientRequest request, Vertx vertx, String clientId, String sessionId) {
		if(!StringUtils.isEmpty(request.getNaewonDateFrom()) && DateUtil.toDate(request.getNaewonDateFrom(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getNaewonDateTo()) && DateUtil.toDate(request.getNaewonDateTo(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}else if(!StringUtils.isEmpty(request.getFromAge()) && CommonUtils.parseInteger(request.getFromAge()) == null){
			return false;
		}else if(!StringUtils.isEmpty(request.getToAge()) && CommonUtils.parseInteger(request.getToAge()) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U03SearchPatientResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U03SearchPatientRequest request) throws Exception {
		ClisServiceProto.CLIS2015U03SearchPatientResponse.Builder response = ClisServiceProto.CLIS2015U03SearchPatientResponse.newBuilder();
		Integer fromAge = CommonUtils.parseInteger(request.getFromAge());
		Integer toAge = CommonUtils.parseInteger(request.getToAge());
		Date naewonDateFrom = DateUtil.toDate(request.getNaewonDateFrom(), DateUtil.PATTERN_YYMMDD);
		Date naewonDateTo = DateUtil.toDate(request.getNaewonDateTo(), DateUtil.PATTERN_YYMMDD);
		
		List<CLIS2015U03PatientListInfo> listResult = out0101Repository.getCLIS2015U03SearchPatient(getHospitalCode(vertx, sessionId), request.getSex(), fromAge, toAge, naewonDateFrom, naewonDateTo, 
				request.getMakerYn(), request.getJoin(), request.getFilterStringOutsang(), request.getFilterStringOcs1003(), request.getFilterStringView(), request.getFilterStringEmr(), 
				request.getFilterCommandOutsang(), request.getFilterCommandOcs1003(), request.getFilterCommandView());
		if(!CollectionUtils.isEmpty(listResult)){
			for(CLIS2015U03PatientListInfo item : listResult){
				ClisModelProto.CLIS2015U03PatientListInfo.Builder info = ClisModelProto.CLIS2015U03PatientListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addPatientListItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}