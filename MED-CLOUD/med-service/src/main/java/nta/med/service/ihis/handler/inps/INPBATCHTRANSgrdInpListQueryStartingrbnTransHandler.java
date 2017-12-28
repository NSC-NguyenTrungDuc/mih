package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.data.model.ihis.inps.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnTransRequest;

@Service
@Scope("prototype")
public class INPBATCHTRANSgrdInpListQueryStartingrbnTransHandler extends ScreenHandler<InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnTransRequest , InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse>{
	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INPBATCHTRANSgrdInpListQueryStartingrbnTransRequest request) throws Exception {
		InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse.Builder response = InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse.newBuilder();
		List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> list = inp1002Repository.getINPBATCHTRANSgrdInpListQueryStartingrbnTransInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getFromDate(), request.getQueryDate(), request.getHoDong1());
		if (!CollectionUtils.isEmpty(list)) {
			for (INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo item : list) {
				InpsModelProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo.Builder info = InpsModelProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkinp1001() != null)
					info.setPkinp1001(CommonUtils.parseString(item.getPkinp1001()));
				if (item.getIpwonDate() != null)
					info.setIpwonDate(DateUtil.toString(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
				if (item.getToiwonResDate() != null)
					info.setToiwonResDate(DateUtil.toString(item.getToiwonResDate(), DateUtil.PATTERN_YYMMDD));
				if (item.getTransDate() != null)
					info.setTransDate(DateUtil.toString(item.getTransDate(), DateUtil.PATTERN_YYMMDD));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
