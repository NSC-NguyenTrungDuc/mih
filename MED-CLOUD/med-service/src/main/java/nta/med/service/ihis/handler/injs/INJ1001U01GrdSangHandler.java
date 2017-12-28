package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.injs.INJ1001U01GrdSangItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class INJ1001U01GrdSangHandler extends ScreenHandler<InjsServiceProto.INJ1001U01GrdSangRequest, InjsServiceProto.INJ1001U01GrdSangResponse> {
	private static final Log LOG = LogFactory.getLog(INJ1001U01GrdSangHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01GrdSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01GrdSangRequest request) throws Exception {
		InjsServiceProto.INJ1001U01GrdSangResponse.Builder response = InjsServiceProto.INJ1001U01GrdSangResponse.newBuilder();
		List<INJ1001U01GrdSangItemInfo> listGrdSangItem = outsangRepository.getINJ1001U01GrdSangItemInfo(getHospitalCode(vertx, sessionId), request.getBunho(),request.getGwa(), request.getReserDate());
    	if (listGrdSangItem != null && !listGrdSangItem.isEmpty()) {
            for (INJ1001U01GrdSangItemInfo item : listGrdSangItem) {
            	InjsModelProto.INJ1001U01GrdSangItemInfo.Builder info = InjsModelProto.INJ1001U01GrdSangItemInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addScheduleItem(info);
            }
    	}
		return response.build();
	}
}
