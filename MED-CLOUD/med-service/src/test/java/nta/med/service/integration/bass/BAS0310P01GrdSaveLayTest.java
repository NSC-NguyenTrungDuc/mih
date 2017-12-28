package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Tiepnm
 */
public class BAS0310P01GrdSaveLayTest extends MessageRequestTest {

    @Test
    public void testBAS0310P01GrdSaveLayTest() throws InterruptedException {

        BassModelProto.BAS0310P01GrdJinryoMasterInfo.Builder dt = BassModelProto.BAS0310P01GrdJinryoMasterInfo.newBuilder();
        dt.setA1("a1");
        dt.setA2("");
        dt.setA3("a3");

        BassModelProto.BAS0310P01GrdJinryoMasterInfo.Builder dt2 = BassModelProto.BAS0310P01GrdJinryoMasterInfo.newBuilder();
        dt2.setA1("a1");
        dt2.setA2("a2");
        dt2.setA3("a3");

        BassModelProto.BAS0310P01GrdJinryoMasterInfo.Builder dt3 = BassModelProto.BAS0310P01GrdJinryoMasterInfo.newBuilder();
        dt3.setA1("a7");
        dt3.setA2("a6");
        dt3.setA3("a5");
        List<BassModelProto.BAS0310P01GrdJinryoMasterInfo> dts =
                new ArrayList<BassModelProto.BAS0310P01GrdJinryoMasterInfo>();
        for(int i = 0; i<5000;i++)
        {
            dts.add(dt.build());
        }
        dts.add(dt2.build());
        dts.add(dt3.build());
        BassServiceProto.BAS0310P01GrdSaveLayRequest request = BassServiceProto.BAS0310P01GrdSaveLayRequest
                .newBuilder().setCurrentType("DrugCode").addAllDt(dts).build();;

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));



        BassServiceProto.BAS0310P01GrdSaveLayRequest request2 = BassServiceProto.BAS0310P01GrdSaveLayRequest
                .newBuilder().setCurrentType("YJCode").addAllDt(dts).build();;

        sentRequestToMedApp(request2, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));


    }
}
