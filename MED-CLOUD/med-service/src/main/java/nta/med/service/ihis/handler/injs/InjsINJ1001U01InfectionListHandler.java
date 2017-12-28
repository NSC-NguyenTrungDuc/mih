package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.nur.Nur1017;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

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
public class InjsINJ1001U01InfectionListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01InfectionListRequest, InjsServiceProto.InjsINJ1001U01InfectionListResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01InfectionListHandler.class);
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01InfectionListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getQueryDate()) && DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01InfectionListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01InfectionListRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01InfectionListResponse.Builder response = InjsServiceProto.InjsINJ1001U01InfectionListResponse.newBuilder();
		List<Nur1017> listObject = nur1017Repository.getInjsINJ1001U01InfectionListItemInfo(getHospitalCode(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD));
        if (!CollectionUtils.isEmpty(listObject)) {
        	InjsModelProto.InjsINJ1001U01InfectionListItemInfo.Builder info =  InjsModelProto.InjsINJ1001U01InfectionListItemInfo.newBuilder();
        	for (Nur1017 item : listObject) {
        		if(!StringUtils.isEmpty(item.getInfeJaeryo())) {
        			info.setInfeJaeryo(item.getInfeJaeryo());
        		}
        		if(!StringUtils.isEmpty(item.getInfeCode())) {
        			info.setInfeCode(item.getInfeCode());
        		}
        		response.addInfectionListItem(info);
        	}
        }
		return response.build();
	}
}
