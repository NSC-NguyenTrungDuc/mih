package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01TempListItemInfo;
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
public class InjsINJ1001U01TempListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01TempListRequest, InjsServiceProto.InjsINJ1001U01TempListResponse>{
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01TempListHandler.class);
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01TempListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01TempListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01TempListRequest request) throws Exception {
		 InjsServiceProto.InjsINJ1001U01TempListResponse.Builder response = InjsServiceProto.InjsINJ1001U01TempListResponse.newBuilder();
		 List<InjsINJ1001U01TempListItemInfo > listObject= out0101Repository.getInjsINJ1001U01TempListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
         		request.getBunho(), request.getDoctor(), DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD),
         		DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD));
         
         if (!CollectionUtils.isEmpty(listObject)) {
         	for (InjsINJ1001U01TempListItemInfo item : listObject) {
         		InjsModelProto.InjsINJ1001U01TempListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01TempListItemInfo.newBuilder();
         		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
         		response.addTempListItem(info);
         	}
         }
		return response.build();
	}
}
