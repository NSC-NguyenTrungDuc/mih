package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.data.model.ihis.injs.INJ0101U00GrdDetailInfo;
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
public class INJ0101U00GrdDetailHandler extends ScreenHandler<InjsServiceProto.INJ0101U00GrdDetailRequest, InjsServiceProto.INJ0101U00GrdDetailResponse> {
	private static final Log LOG = LogFactory.getLog(INJ0101U00GrdDetailHandler.class);
	@Resource
	private Inj0102Repository inj0102Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0101U00GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00GrdDetailRequest request) throws Exception {
		InjsServiceProto.INJ0101U00GrdDetailResponse.Builder response = InjsServiceProto.INJ0101U00GrdDetailResponse.newBuilder();
		List<INJ0101U00GrdDetailInfo> listResult = inj0102Repository.getINJ0101U00GrdDetailInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listResult)) {
        	for (INJ0101U00GrdDetailInfo item : listResult) {
        		InjsModelProto.INJ0101U00GrdDetailInfo.Builder info = InjsModelProto.INJ0101U00GrdDetailInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getCodeType())) {
        			info.setCodeType(item.getCodeType());
        		}
        		if (!StringUtils.isEmpty(item.getCode())) {
        			info.setCode(item.getCode());
        		}
        		if (!StringUtils.isEmpty(item.getCodeName())) {
        			info.setCodeName(item.getCodeName());
        		}
	            response.addListItem(info);
        	}
        }
		return response.build();
	}	
}
