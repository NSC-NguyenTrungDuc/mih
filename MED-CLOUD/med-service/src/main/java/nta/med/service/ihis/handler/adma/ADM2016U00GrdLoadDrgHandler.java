package nta.med.service.ihis.handler.adma;

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
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm9983Repository;
import nta.med.data.model.ihis.adma.ADM2016U00GrdLoadDrgInfo;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class ADM2016U00GrdLoadDrgHandler extends ScreenHandler<AdmaServiceProto.ADM2016U00GrdLoadDrgRequest, AdmaServiceProto.ADM2016U00GrdLoadDrgResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM2016U00GrdLoadDrgHandler.class);           
	
	@Resource                                                                                                       
	private Adm9983Repository adm9983Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public AdmaServiceProto.ADM2016U00GrdLoadDrgResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM2016U00GrdLoadDrgRequest request) throws Exception {
		AdmaServiceProto.ADM2016U00GrdLoadDrgResponse.Builder response = AdmaServiceProto.ADM2016U00GrdLoadDrgResponse.newBuilder();	
	
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		
		List<ADM2016U00GrdLoadDrgInfo> listItem = adm9983Repository.getADM2016U00GrdLoadDrgInfo(getHospitalCode(vertx, sessionId), request.getSearchName(), request.getSearchType(), request.getSearchAccount(), startNum, CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ADM2016U00GrdLoadDrgInfo item : listItem) {
				AdmaModelProto.ADM2016U00GrdLoadDrgInfo.Builder builder = AdmaModelProto.ADM2016U00GrdLoadDrgInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addItemInfo(builder);
			}
		}
		
		return response.build();
	}
}
