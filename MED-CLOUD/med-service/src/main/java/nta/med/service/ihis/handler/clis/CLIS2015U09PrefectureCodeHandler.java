package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0102;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09PrefectureCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U09PrefectureCodeHandler extends ScreenHandler<CLIS2015U09PrefectureCodeRequest, ComboResponse>{
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CLIS2015U09PrefectureCodeRequest request)
			throws Exception {
		ComboResponse.Builder response  = ComboResponse.newBuilder();
		
		List<Bas0102> listBas0102 = bas0102Repository.getAllByLikeCodeAndCodeType(getHospitalCode(vertx, sessionId), "%"+request.getFind1()+"%", "DODOBUHYEUN_NO", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listBas0102)){
			for(Bas0102 item : listBas0102){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeName(item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
		
	}

}
