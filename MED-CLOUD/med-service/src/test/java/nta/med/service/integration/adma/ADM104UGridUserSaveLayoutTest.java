package nta.med.service.integration.adma;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Tiepnm
 */
public class ADM104UGridUserSaveLayoutTest extends MessageRequestTest {

    @Test
    public void testADM104UGridUserSaveLayout() throws InterruptedException {
        AdmaModelProto.ADM104UGridUserInfo.Builder info = AdmaModelProto.ADM104UGridUserInfo.newBuilder();
        info.setDataRowState(DataRowState.ADDED.getValue());
        info.setUserId("K01HHH");
        info.setUserScrt("b59c67bf196a4758191e42f76670ceba");
        info.setUserLevel("3");
        info.setIschangePwd("1");
        info.setPwdHistory("b59c67bf196a4758191e42f76670ceba");
        info.setChangePwdFlg("Y");
        List<AdmaModelProto.ADM104UGridUserInfo> infoList = new ArrayList<AdmaModelProto.ADM104UGridUserInfo>();
        infoList.add(info.build());

        AdmaServiceProto.ADM104UGridUserSaveLayoutRequest request = AdmaServiceProto.ADM104UGridUserSaveLayoutRequest.newBuilder().setHospCode("K01").addAllItemInfo(infoList).build();

        sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

    }
}
