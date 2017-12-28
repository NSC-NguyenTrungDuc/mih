package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.config.Configuration;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FormEnvironInfoSysDateTimeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")   
public class FormEnvironInfoSysDateTimeHandler 
	extends ScreenHandler<SystemServiceProto.FormEnvironInfoSysDateTimeRequest, SystemServiceProto.StringResponse>{                     
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Bas0001Repository bas0001Repository;

	@Resource
	private Configuration configuration;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			FormEnvironInfoSysDateTimeRequest request) throws Exception {
  	   	SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		Integer timeZone = getTimeZone(vertx, sessionId) ;
		if(timeZone == null) {
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(getHospitalCode(vertx, sessionId));

			if (!CollectionUtils.isEmpty(bas0001List)) {
				Bas0001 bas0001 = bas0001List.get(0);
				timeZone = bas0001.getTimeZone();

			}
			if(timeZone == null)
			{
				timeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;
			}
		}

		Integer defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;
		Integer offset = defaultTimeZone - timeZone;

		String result = commonRepository.getFormEnvironInfoSysDate(offset, DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS) ;
		response.setResult(result);
		return response.build();
	}
}
