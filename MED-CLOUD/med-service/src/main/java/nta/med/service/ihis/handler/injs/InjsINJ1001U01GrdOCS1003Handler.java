package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01GrdOCS1003ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01GrdOCS1003Handler extends ScreenHandler<InjsServiceProto.INJ1001U01GrdOCS1003Request, InjsServiceProto.INJ1001U01GrdOCS1003Response>{
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01GrdOCS1003Handler.class);
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Override
	public boolean isValid(InjsServiceProto.INJ1001U01GrdOCS1003Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01GrdOCS1003Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01GrdOCS1003Request request) throws Exception {
		InjsServiceProto.INJ1001U01GrdOCS1003Response.Builder response = InjsServiceProto.INJ1001U01GrdOCS1003Response.newBuilder();
		List<InjsINJ1001U01GrdOCS1003ItemInfo> getgrdOcs1003List = ocs1003Repository.getINJ1001U01GrdOCS1003ItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),
					DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_DDMMYYYY) ,DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_DDMMYYYY) );
			if(!CollectionUtils.isEmpty(getgrdOcs1003List)){	
				for(InjsINJ1001U01GrdOCS1003ItemInfo item :getgrdOcs1003List){
					InjsModelProto.INJ1001U01GrdOCS1003ItemInfo.Builder info= InjsModelProto.INJ1001U01GrdOCS1003ItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdOcs1003Item(info);
				}
			}
		return response.build();
	}
}
