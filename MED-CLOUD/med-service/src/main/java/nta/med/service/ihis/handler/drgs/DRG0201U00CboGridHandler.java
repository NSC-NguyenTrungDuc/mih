package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.inv.Inv0102;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.drg.Drg9043Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class DRG0201U00CboGridHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00CboGridRequest, DrgsServiceProto.DRG0201U00CboGridResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00CboGridHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;
    @Resource
    private Inv0102Repository inv0102Repository;
    @Resource
    private Drg9043Repository drg9043Repository;

    @Override
    @org.springframework.transaction.annotation.Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00CboGridResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00CboGridRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00CboGridResponse.Builder response = DrgsServiceProto.DRG0201U00CboGridResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<Adm3200> listAdm3200 = adm3200Repository.getByUserGroupAndUserEndYmd(hospitalCode, "DRG", new Date());
        CommonModelProto.ComboListItemInfo.Builder headerCombo = CommonModelProto.ComboListItemInfo.newBuilder();
        headerCombo.setCode("USER_ID");
        headerCombo.setCodeName("USER_NM");
        response.addCbxActor(headerCombo);
        if (!CollectionUtils.isEmpty(listAdm3200)) {
            for (Adm3200 item : listAdm3200) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getUserId())) {
                    info.setCode(item.getUserId());
                }
                if (!StringUtils.isEmpty(item.getUserNm())) {
                    info.setCodeName(item.getUserNm());
                }
                response.addCbxActor(info);
            }
        }
        List<Inv0102> listInv0102 = inv0102Repository.findByCodeType(hospitalCode, "DRG_CONSTANT", language);
        if (!CollectionUtils.isEmpty(listInv0102)) {
            for (Inv0102 item : listInv0102) {
                CommonModelProto.TripleListItemInfo.Builder info = CommonModelProto.TripleListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setItem1(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCodeName())) {
                    info.setItem2(item.getCodeName());
                }
                if (!StringUtils.isEmpty(item.getCodeValue())) {
                    info.setItem3(item.getCodeValue());
                }
                response.addMlayConstantInfo(info);
            }
        }
        List<String> lockStr = drg9043Repository.validateLock(hospitalCode);
        if (!CollectionUtils.isEmpty(lockStr)) {
            String lockChk = lockStr.get(0);
            response.setLockChk(lockChk);
        }
        return response.build();
    }
}
