package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layMaxBedNoRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layMaxBedNoResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class BAS0250Q00layMaxBedNoHandler extends
		ScreenHandler<BassServiceProto.BAS0250Q00layMaxBedNoRequest, BassServiceProto.BAS0250Q00layMaxBedNoResponse> {
	
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250Q00layMaxBedNoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250Q00layMaxBedNoRequest request) throws Exception {
		
		BassServiceProto.BAS0250Q00layMaxBedNoResponse.Builder response = BassServiceProto.BAS0250Q00layMaxBedNoResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Date hoCodeYmd = DateUtil.toDate(request.getHoCodeYmd(), DateUtil.PATTERN_YYMMDD);
		
		List<DataStringListItemInfo> lstInfo = bas0250Repository.getBAS0250Q00layMaxBedNoInfoList(hospCode, request.getHoDong(), hoCodeYmd);

		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (DataStringListItemInfo info : lstInfo) {
			CommonModelProto.DataStringListItemInfo.Builder protoInfo = CommonModelProto.DataStringListItemInfo.newBuilder();
			protoInfo.setDataValue(info.getItem());
			response.addLayItem(protoInfo);
		}
		
		return response.build();
	}

}
