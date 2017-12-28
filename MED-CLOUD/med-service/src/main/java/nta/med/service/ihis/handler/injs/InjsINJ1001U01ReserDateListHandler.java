package nta.med.service.ihis.handler.injs;

import java.sql.Timestamp;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
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
public class InjsINJ1001U01ReserDateListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01ReserDateListRequest, InjsServiceProto.InjsINJ1001U01ReserDateListResponse>{
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01ReserDateListHandler.class);
	@Resource
	private Inj1002Repository inj1002Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01ReserDateListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01ReserDateListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01ReserDateListRequest request) throws Exception {
		 List<Timestamp> result = inj1002Repository.getInjsINJ1001U01ReserDateList(getHospitalCode(vertx, sessionId), request.getBunho(), request.getDoctor(), DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD), request.getActingFlag());
         InjsServiceProto.InjsINJ1001U01ReserDateListResponse.Builder response = InjsServiceProto.InjsINJ1001U01ReserDateListResponse.newBuilder();
         if (!CollectionUtils.isEmpty(result)) {
         	for (Timestamp item : result) {
         		if(item != null) {
         			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
         			info.setDataValue(item.toString());
         			response.addReserDate(info);
         		}
         	}
         }
		return response.build();
	}
}
