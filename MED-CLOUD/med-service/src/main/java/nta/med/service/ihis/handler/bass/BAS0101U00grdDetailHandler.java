package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.bass.BAS0101U00grdDetailItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00grdDetailRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00grdDetailResponse;

@Service
@Scope("prototype")
public class BAS0101U00grdDetailHandler extends ScreenHandler<BassServiceProto.BAS0101U00grdDetailRequest, BassServiceProto.BAS0101U00grdDetailResponse>{
	private static final Log LOGGER = LogFactory.getLog(BAS0101U00grdDetailHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0101U00grdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0101U00grdDetailRequest request)
			throws Exception {
		
		BassServiceProto.BAS0101U00grdDetailResponse.Builder response=BassServiceProto.BAS0101U00grdDetailResponse.newBuilder();
		List<BAS0101U00grdDetailItemInfo> listGrdDetail = bas0102Repository.listBAS0101U00GrdDetail(getHospitalCode(vertx, sessionId),request.getCodeType(),getLanguage(vertx, sessionId));
		
		if(listGrdDetail !=null && !listGrdDetail.isEmpty()){
			for(BAS0101U00grdDetailItemInfo item : listGrdDetail){
				BassModelProto.BAS0101U00grdDetailItemInfo.Builder info = BassModelProto.BAS0101U00grdDetailItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDetail(info);
			}
		}
		
		return response.build();
	}

}
