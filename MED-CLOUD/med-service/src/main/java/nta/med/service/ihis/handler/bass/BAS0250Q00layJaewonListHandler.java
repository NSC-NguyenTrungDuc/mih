package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.bass.BAS0250Q00layJaewonListInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layJaewonListRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layJaewonListResponse;

@Service
@Scope("prototype")
public class BAS0250Q00layJaewonListHandler extends
		ScreenHandler<BassServiceProto.BAS0250Q00layJaewonListRequest, BassServiceProto.BAS0250Q00layJaewonListResponse> {
	private static final Log LOGGER = LogFactory.getLog(BAS0250Q00layJaewonListHandler.class); 
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250Q00layJaewonListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250Q00layJaewonListRequest request) throws Exception {
		
		BassServiceProto.BAS0250Q00layJaewonListResponse.Builder response = BassServiceProto.BAS0250Q00layJaewonListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<BAS0250Q00layJaewonListInfo> lstInfo = inp1001Repository.getBAS0250Q00layJaewonListInfoList(hospCode, request.getHoDong(), language);

		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (BAS0250Q00layJaewonListInfo info : lstInfo) {
			BassModelProto.BAS0250Q00layJaewonListInfo.Builder protoInfo = BassModelProto.BAS0250Q00layJaewonListInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addLayItem(protoInfo);
		}
		
		return response.build();
	}

}
