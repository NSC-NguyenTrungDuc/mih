package nta.med.service.ihis.handler.nuro;

import java.math.BigInteger;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.nuro.KcckApiDoctorInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class KcckApiSearchDoctorsHandler extends ScreenHandler<NuroServiceProto.KcckApiSearchDoctorsRequest, NuroServiceProto.KcckApiSearchDoctorsResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(KcckApiSearchDoctorsHandler.class);
	
	@Resource
	private Bas0270Repository bas0270Repository;

	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository; 
	
	@Override
	@Transactional(readOnly = true)
    @Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.KcckApiSearchDoctorsRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					StringUtils.isEmpty(request.getLocale()) ? bas0001.getLanguage() : request.getLocale(), "", 1, ""));
		} else {
			LOGGER.info("KcckApiSearchDoctorsRequest preHandle not found hosp code");
		}
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.KcckApiSearchDoctorsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.KcckApiSearchDoctorsRequest request) throws Exception {
		NuroServiceProto.KcckApiSearchDoctorsResponse.Builder response = NuroServiceProto.KcckApiSearchDoctorsResponse.newBuilder();
		String offset = request.getPageSize();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageIndex(), offset);
		List<KcckApiDoctorInfo> listObject = bas0270Repository.getKcckApiSearchDoctors(request.getHospCode(), request.getDepartment(), request.getStartDate(), request.getEndDate(), request.getLocale(),
				request.getReservationDate(), request.getReservationTime(), CommonUtils.parseInteger(offset), startNum);
        if (listObject != null && !listObject.isEmpty()) {
            for (KcckApiDoctorInfo item : listObject) {
            	NuroModelProto.KcckApiGetDoctorInfo.Builder info = NuroModelProto.KcckApiGetDoctorInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListDoctor(info);
            }
        }
        
        BigInteger totalRecords = bas0270Repository.getKcckApiTotalRecordSearchDoctors(request.getHospCode(), request.getDepartment(), request.getStartDate(), request.getEndDate(), request.getLocale(),
				request.getReservationDate(), request.getReservationTime());
        
        response.setTotalRecords(totalRecords.toString());
		return response.build();
	}
}
