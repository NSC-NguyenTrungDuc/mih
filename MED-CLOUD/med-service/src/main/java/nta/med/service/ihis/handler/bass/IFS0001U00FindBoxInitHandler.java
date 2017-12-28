package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.impl.Bas0102RepositoryImpl;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00FindBoxInitRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")
public class IFS0001U00FindBoxInitHandler extends ScreenHandler<IFS0001U00FindBoxInitRequest, ComboResponse> {
	@Resource
	private Bas0102RepositoryImpl bas0102RepositoryImpl;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, IFS0001U00FindBoxInitRequest request)
			throws Exception {
		ComboResponse.Builder response = ComboResponse.newBuilder();
		List<ComboListItemInfo> listResult = bas0102RepositoryImpl.getOcsoOUTSANGU00FindWorker(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getCode());
		String language = getLanguage(vertx, sessionId);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addComboItem(info);
			}
		}
		return response.build();
	}

	
}
